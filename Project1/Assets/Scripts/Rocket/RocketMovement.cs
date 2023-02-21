using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour{
    [SerializeField] float movementSpeed = 100f;

    Rigidbody2D rigidbodyComponent;

    private void Start() {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        MovingRocket();
    }
    
    void MovingRocket() {
        Vector2 movingDirection = new Vector2(movementSpeed * Time.deltaTime, 0);
        rigidbodyComponent.AddForce(movingDirection);
    }
}
