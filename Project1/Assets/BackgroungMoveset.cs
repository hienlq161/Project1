using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungMoveset : MonoBehaviour
{
    [SerializeField] float speed;
    private Transform trans;
    public float timmer;
    float counter;
    float dir;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        dir = 1;
       
    }
    private void Update()
    {
        
      
            trans.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        trans.Translate(new Vector3(0, dir * speed / 10 * Time.deltaTime));
            if (counter > timmer)
        {
            dir = -dir;
            counter = 0;
        }
        counter += Time.deltaTime;
     
        
    }
    
}
