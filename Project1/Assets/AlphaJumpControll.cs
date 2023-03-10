using UnityEngine;

public class AlphaJumpControll : MonoBehaviour
{
    SpriteRenderer sprt;
    GameObject arrow;
    private void Awake()
    {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        sprt = arrow.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rocket"))
        {
            Debug.LogError("hehe");

            sprt.color = new Color(sprt.color.r, sprt.color.g, sprt.color.b, 255);
        }
    }
}
