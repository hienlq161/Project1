using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour{

    [SerializeField] float delayTime = 2f;

    [SerializeField] AudioClip destroyContact;
    AudioSource audioSourceComponent;

    private void Start() {
        audioSourceComponent = GetComponent<AudioSource>();
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
    void OnEnable() {
        EventManager.StartSequence += StartGame;
    }
    void OnDisable() {
        EventManager.StartSequence -= StartGame;
    }

    void StartGame() {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Friendly")) {
            return;
        }
        if (collision.gameObject.CompareTag("AlphaJump")) {
            return;
        }
        if (collision.gameObject.CompareTag("ForceRadius")) {
            return;
        }
        if (collision.gameObject.CompareTag("Planet")) {
            return;
        }
        if (collision.gameObject.TryGetComponent<CollisionHandler>(out CollisionHandler collisionScript)) {
            if (collisionScript.isTransitioning) return;
        }
        Destroy(collision.gameObject);
        audioSourceComponent.PlayOneShot(destroyContact, 0.5f);
        //play some kind of animation
        if (collision.gameObject.CompareTag("Rocket")) {
            Invoke(nameof(TriggerGameOver), delayTime);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Friendly")) {
            return;
        }
        if (collision.gameObject.CompareTag("AlphaJump")) {
            return;
        }
        if (collision.gameObject.CompareTag("ForceRadius")) {
            return;
        }
        if (collision.gameObject.CompareTag("Planet")) {
            return;
        }
        if (collision.gameObject.TryGetComponent<CollisionHandler>(out CollisionHandler collisionScript)) {
            if (collisionScript.isTransitioning) return;
        }
        Destroy(collision.gameObject);
        audioSourceComponent.PlayOneShot(destroyContact, 0.5f);
        //play some kind of animation
        if (collision.gameObject.CompareTag("Rocket")) {
            Invoke(nameof(TriggerGameOver), delayTime);
        }
    }
    void TriggerGameOver() {
        GameManager.instance.GameOver();
    }
}
