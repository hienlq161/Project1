using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour{

    Vector3 initiateVector;
    Vector3 mousePosition;
    bool isStartingSequence;

    private void Start() {
        isStartingSequence = false;
    }
    private void OnEnable() {
        EventManager.StartSequence += EnableSequence;
    }
    private void OnDisable() {
        EventManager.StartSequence -= EnableSequence;
    }

    void EnableSequence() {
        isStartingSequence = true;
    }

    private void OnMouseDown() {
        GetComponent<MaintainPosition>().enabled = false;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initiateVector = mousePosition - transform.position;
    }
    private void OnMouseDrag() {
        if (isStartingSequence) {
            return;
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition - initiateVector;
    }
    private void OnMouseExit() {
        GetComponent<MaintainPosition>().enabled = true;
    }
}
