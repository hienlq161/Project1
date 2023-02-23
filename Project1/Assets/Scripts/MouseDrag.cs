using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour{

    Vector3 initiateVector;
    Vector3 mousePosition;

    private void OnMouseDown() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initiateVector = mousePosition - transform.position;
    }
    private void OnMouseDrag() {
        GetComponent<MaintainPosition>().enabled = false;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition - initiateVector;
    }
    private void OnMouseExit() {
        GetComponent<MaintainPosition>().enabled = true;
    }
}
