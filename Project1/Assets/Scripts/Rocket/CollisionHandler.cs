
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour{

    [SerializeField] float delayTime = 2f;
    [SerializeField] Vector3 shrinkRate = new Vector3(0.1f, 0.1f, 0.1f);

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Friendly")) {
            return;
        }
        if (collision.gameObject.CompareTag("FroceRadius")) {
            return;
        }
        if (collision.gameObject.CompareTag("AlphaJump")) {
            NextLevelSequence();
            return;
        }
        // ship got destroy
    }

    void NextLevelSequence() {
        //Implement animation and other stuff
        Invoke(nameof(LoadNextLevel), delayTime);
    }
    void LoadNextLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            // end of all level, congrat player(s)
        }
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }    
}
