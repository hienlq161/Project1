using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour{

    [SerializeField] float movementSpeed = 100f;

    Rigidbody2D rigidbodyComponent;

    bool isMovingEnable = false;

    private void Start() {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        isMovingEnable = false;
    }
    private void Update() {
        MovingRocket();
    }

    void OnEnable() {
        EventManager.StartSequence += EnableMoving;
    }
    void OnDisable() {
        EventManager.StartSequence -= EnableMoving; 
    }


    void EnableMoving() { 
        isMovingEnable = true;
    }
    void MovingRocket() {
        if (isMovingEnable == false) return;
        Vector2 movingDirection = new Vector2(movementSpeed * Time.deltaTime, 0);
        rigidbodyComponent.AddRelativeForce(movingDirection);
    }
}
