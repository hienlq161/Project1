using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    

    [SerializeField] private Transform otherHole;
    [SerializeField] private GameObject congkia;
    private void Awake()
    {
     
        
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rocket"))
        {
            other.GetComponent<Animator>().SetTrigger("disapear");
            StartCoroutine(delayTurnOffCollider(1.5f));
            StartCoroutine(delay(0.1f, other.transform));
         }
        else if (other.CompareTag("SaoBang"))
        {
            other.GetComponent<Animator>().SetTrigger("disapear");
            congkia.GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(delayTurnOffCollider(1.5f));
            StartCoroutine(delay(0.1f, other.transform));



        }
    }
    public void MoveToOtherHole(Transform item)
    {
        
        item.position = otherHole.position;
        item.GetComponent<Animator>().SetTrigger("appear");
    }
    IEnumerator delay(float sec, Transform other)
    {
        for (int i = 0; i <= 3; i++)
        {
            yield return new WaitForSeconds(sec);
        }
        MoveToOtherHole(other.transform);
        for (int i = 0; i <= 1; i++)
        {
            yield return new WaitForSeconds(sec);
        }
    }
    IEnumerator delayTurnOffCollider(float wait)
    {
        yield return new WaitForSeconds(wait);
        congkia.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
