using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float momentXoay;
    [SerializeField] public AudioClip planeExplore;
    Animator anim;
    private void Awake()
    {
      anim = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, momentXoay * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SaoBang"))
        {
            SoundManager.Instance.PlaySound(planeExplore);
            anim.SetTrigger("explore");
        }
      
    }
    void Explore()
    {
        gameObject.SetActive(false);
    }
}
