
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour{

    [SerializeField] float delayTime = 2f;

    SpriteRenderer spriteRendererComponent;

    Vector3 rocketScreenPosition;
    bool isOffScreen;

    private void Start() {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        rocketScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        isOffScreen = rocketScreenPosition.x >= Screen.width || rocketScreenPosition.y >= Screen.height;

        if (isOffScreen) {
            DestroyShip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Friendly")) {
            return;
        }
        if (collision.gameObject.CompareTag("ForceRadius")) {
            return;
        }
        if (collision.gameObject.CompareTag("AlphaJump")) {
            NextLevelSequence();
            return;
        }
        DestroyShip();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.CompareTag("SaoBang") || collision.collider.CompareTag("ThienThach") ){
            DestroyShip();
        }
    }

    void NextLevelSequence() {
        //Implement animation and other stuff
        LevelSelectControl.instance.UnLockLevel(SceneManager.GetActiveScene().buildIndex);
        LevelSelectControl.instance.lockLv = SceneManager.GetActiveScene().buildIndex + 1;
        print(SceneManager.GetActiveScene().buildIndex);
        Invoke(nameof(LoadNextLevel), delayTime);
    }
    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            // end of all level, congrat player(s)
        }
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }    

    void DestroyShip() {
        spriteRendererComponent.enabled = false;
        Invoke(nameof(CallGameOver), delayTime);
    }
    void CallGameOver() {
        GameManager.instance.GameOver();
    }
}
