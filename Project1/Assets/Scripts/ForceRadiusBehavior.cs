using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRadiusBehavior : MonoBehaviour{

    [SerializeField] float attractiveForce = 80f;
    [SerializeField] float dragAmount = 0.7f;
    [SerializeField] float rotationSpeed = 50f;

    [SerializeField] Transform coreTransform;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("BlackHole")) {
            return;
        }
        if (collision.CompareTag("AlphaJump")) {
            return;
        }
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D objectRigidbody)) {
            Transform objectTransform = collision.gameObject.transform;
            float objectMass = objectRigidbody.mass;
            Vector3 objectPosition = objectTransform.position;
            Vector3 forceDirection = (coreTransform.position - objectPosition).normalized;
            
            objectRigidbody.drag = dragAmount;
            objectRigidbody.AddForce(objectMass * attractiveForce * Time.deltaTime * forceDirection);

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, forceDirection);
            objectTransform.rotation = Quaternion.RotateTowards(objectTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
