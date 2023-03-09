using UnityEngine;

public class ThienThach : MonoBehaviour
{
    [SerializeField] float momenXoayTrucZ;
    
    [SerializeField] float speed;
    [SerializeField] Vector2 dir;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
        transform.Rotate(new Vector3(0, 0, momenXoayTrucZ * Time.deltaTime));
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rocket")) anim.SetTrigger("explore");
    }
}

