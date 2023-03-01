using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour{

    [SerializeField] float delayTime = 2f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Friendly")) {
            return;
        }
        if (collision.gameObject.CompareTag("AlphaJump")) {
            return;
        }

        Destroy(collision.gameObject);
        //play some kind of animation
        if (collision.gameObject.CompareTag("Rocket")) {
            Invoke(nameof(TriggerGameOver), delayTime);
        }
    }
    void TriggerGameOver() {
        GameManager.instance.GameOver();
    }
}
