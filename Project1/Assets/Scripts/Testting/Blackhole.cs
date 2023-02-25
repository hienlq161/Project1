using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Blackhole : MonoBehaviour
{
    [SerializeField] public float GRAVITY_PULL = .78f;
    public static float m_GravityRadius = 1f;
    private float goc;
    void Awake()
    {
        m_GravityRadius = GetComponent<CircleCollider2D>().radius;
    }
    /// <summary>
    /// Attract objects towards an area when they come within the bounds of a collider.
    /// This function is on the physics timer so it won't necessarily run every frame.
    /// </summary>
    /// <param name="other">Any object within reach of gravity's collider</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position) * 1 / gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
             
            Vector3 dis = transform.position - other.transform.position;
            goc = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
           if (goc > 0)  goc = (goc > 90) ? (180 - goc) : (goc);
               else goc = (goc < -90) ? (goc + 90) : (goc);
            print(goc);
            
            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            Vector2 dir = new Vector2(Mathf.Cos(goc * Mathf.Deg2Rad), Mathf.Sin(goc * Mathf.Deg2Rad));
            dir = dir.normalized;
            other.GetComponent<SpaceShip>().SetGocBay(dir);

        }
    }
}