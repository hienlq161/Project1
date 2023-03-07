using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour{

    [SerializeField] GameObject blackHole;

    Vector3 mousePosition;
    private void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
        if (Input.GetMouseButtonDown(0))  {
            Instantiate(blackHole, mousePosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
