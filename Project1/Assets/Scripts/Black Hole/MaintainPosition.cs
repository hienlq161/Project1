using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainPosition : MonoBehaviour{

    [SerializeField] Transform target;

    void Update() {
        MaintainPositionWithTarget();
    }

    void MaintainPositionWithTarget() {
        this.transform.position = target.position;
    }

}
