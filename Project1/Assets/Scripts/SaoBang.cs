using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaoBang : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject rocket;
    Vector3 shot;
    Vector3 dir; 
    float goc;

    bool isStartingSequence;

    private void Start()
    {
        isStartingSequence = false;
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        shot = rocket.transform.position;
        shot = shot - transform.position;
        goc = Mathf.Atan2(shot.y, shot.x);
        dir = new Vector3(Mathf.Cos(goc), Mathf.Sin(goc));
        print(shot.ToString());
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

    private void Update()
    {
        if (isStartingSequence == false) {
            return;
        }
        if (Mathf.Abs(goc) > 0)
        {
            Quaternion rotate = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, speed * Time.deltaTime / 2); ; 
        }
        transform.Translate(shot * speed * Time.deltaTime, relativeTo: Space.World) ;
      

    }
}
