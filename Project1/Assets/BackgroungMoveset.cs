using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungMoveset : MonoBehaviour
{
    [SerializeField] Transform leTren;
    [SerializeField] Transform leDuoi;
    [SerializeField] float speed;
    Vector3 oldPos;
    private Transform trans;
    bool moveDown;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        oldPos = trans.position;
       
    }
    private void Update()
    {
        
        if (trans.position.y < leTren.position.y) trans.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
        else
        {
            new WaitForEndOfFrame();
            trans.position = oldPos ;
             
        }
        
    }
    
}
