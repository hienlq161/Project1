
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour{

    [SerializeField] float delayTime = 2f;

    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip explosionAudio;
    [SerializeField] AudioClip alphaJumpAudio;
    SpriteRenderer spriteRendererComponent;
    AudioSource audioSourceComponent;

    Vector3 rocketScreenPosition;
    bool isOffScreen;
    bool isTransitioning;

    private void Start() {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
        audioSourceComponent = GetComponent<AudioSource>();
        isTransitioning = false;
    }

    private void Update() {
        if (isTransitioning) {
            return;
        }

        rocketScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        isOffScreen = rocketScreenPosition.x >= Screen.width || rocketScreenPosition.y >= Screen.height;

        if (isOffScreen) {
            DestroyShip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isTransitioning) {
            return;
        }
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
        if (isTransitioning) {
            return;
        }
        if (collision.gameObject.CompareTag("BlackHole")) {
            return;
        }
        //if (collision.collider.CompareTag("SaoBang")){
        //    DestroyShip();
        //}
        DestroyShip();
    }

    void NextLevelSequence() {
        isTransitioning = true;
        audioSourceComponent.PlayOneShot(alphaJumpAudio);
        Invoke(nameof(LoadNextLevel), delayTime);
    }
    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            // end of all level, congrat player(s)
            SceneManager.LoadSceneAsync("level 0");
            return;
        }
        print(currentSceneIndex);
        if (LevelSelectControl.lockLv < currentSceneIndex) LevelSelectControl.lockLv++;
        SceneManager.LoadSceneAsync(nextSceneIndex);
    }    

    void DestroyShip() {
        if (isTransitioning) {
            return;
        }
        if (!isOffScreen) {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            audioSourceComponent.PlayOneShot(explosionAudio);
        }
        spriteRendererComponent.enabled = false;
        isTransitioning = true;
        Invoke(nameof(CallGameOver), delayTime);
    }
    void CallGameOver() {
        GameManager.instance.GameOver();
    }
}
