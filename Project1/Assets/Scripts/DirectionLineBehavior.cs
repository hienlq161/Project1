using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLineBehavior : MonoBehaviour{
    private void OnEnable() {
        EventManager.StartSequence += DisableLine;
    }
    private void OnDisable() {
        EventManager.StartSequence -= DisableLine;
    }
    private void Update()
    {
        
    }
    void DisableLine() {
        Destroy(gameObject);
    }
}
