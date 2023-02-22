using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRadiusBehavior : MonoBehaviour{

    [SerializeField] float attractiveForce = 80f;
    [SerializeField] float dragAmount = 0.7f;

    [SerializeField] Transform coreTransform;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("BlackHole")) {
            return;
        }
        if (collision.CompareTag("AlphaJump")) {
            return;
        }
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D objectRigidbody)) {
            float objectMass = objectRigidbody.mass;
            Vector3 objectPosition = collision.gameObject.transform.position;

            objectRigidbody.drag = dragAmount;
            Vector3 forceDirection = (coreTransform.position - objectPosition).normalized;
            objectRigidbody.AddForce(objectMass * attractiveForce * Time.deltaTime * forceDirection);

        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("BlackHole")) {
            return;
        }
        if (collision.CompareTag("AlphaJump")) {
            return;
        }
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D objectRigidbody)) {
            objectRigidbody.drag = 0;
        }
    }

}
