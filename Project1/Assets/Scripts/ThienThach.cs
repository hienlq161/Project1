using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThienThach : MonoBehaviour
{
    [SerializeField] float momenXoayTrucZ;
    
    [SerializeField] float speed;
    [SerializeField] Vector2 dir;
    private void Update()
    {
        
        transform.Rotate(new Vector3(0, 0, momenXoayTrucZ * Time.deltaTime));
        transform.Translate(dir * speed * Time.deltaTime);
    }
}

