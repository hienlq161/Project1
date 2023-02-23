using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMoveset : MonoBehaviour
{
    
    [SerializeField] float speed ;
    [SerializeField] float amplitude;
     float y0;
    private Vector3 tempPos;
    private void Start()
    {
        y0 = transform.position.y;
        tempPos = transform.position;
    }
    void Update()
    {
        tempPos.y = y0 + amplitude * Mathf.Sin(speed * Time.time);
        transform.position= tempPos;
    }
}
