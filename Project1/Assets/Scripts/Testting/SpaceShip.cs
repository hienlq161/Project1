using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] Vector3 gocBay;

    // Update is called once per frame
    private void Start()
    {
        gocBay = new Vector3(1, 0 , 0 );
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = gocBay * speed; 
        if (gocBay != Vector3.zero)
        {
            Quaternion toRatate = Quaternion.LookRotation(Vector3.forward, gocBay);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRatate, speed * Time.deltaTime / 2);
        }
    }
    public void SetGocBay(Vector3 _gocbay)
    {
        gocBay = _gocbay;
    }
}
