using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour{

    [SerializeField] float movementSpeed = 100f;
    Animator animatorComponent;

    Rigidbody2D rigidbodyComponent;

    bool isMovingEnable;


    private void Awake() {
        animatorComponent = GetComponent<Animator>();
    }
    private void Start() {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        isMovingEnable = false;
        animatorComponent.SetBool("isMoving", false);
    }
    private void FixedUpdate() {
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
        animatorComponent.SetBool("isMoving", true);
        Vector2 movingDirection = new Vector2(0, movementSpeed * Time.deltaTime);
        rigidbodyComponent.AddRelativeForce(movingDirection);
    }
}
