using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    

    [SerializeField] private Transform otherHole;
    [SerializeField] private GameObject congkia;
    [SerializeField] public AudioClip intoWormHole;
    GameObject rocket;
    Color oldColor;
    private void Awake()
    {
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        oldColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(oldColor.r, oldColor.g, oldColor.b, 255);
        if (other.CompareTag("Rocket"))
        {
            SoundManager.Instance.PlaySound(intoWormHole);
            other.GetComponent<Animator>().SetTrigger("disapear");
            StartCoroutine(delayTurnOffCollider(1.5f));
            StartCoroutine(delay(0.1f, other.transform));
         }
        else if (other.CompareTag("SaoBang"))
        {
            SoundManager.Instance.PlaySound(intoWormHole);
            other.GetComponent<Animator>().SetTrigger("disapear");
            congkia.GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(delayTurnOffCollider(1.5f));
            StartCoroutine(delay(0.1f, other.transform));



        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = oldColor;
    }
    public void MoveToOtherHole(Transform item)
    {
        
        item.position = otherHole.position;
        float sig = otherHole.position.x - congkia.transform.position.x;
        if (rocket.GetComponent<Rigidbody2D>().velocity.x * sig < 0) rocket.GetComponent<Rigidbody2D>().velocity *= new Vector3(-1,1,1);
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
