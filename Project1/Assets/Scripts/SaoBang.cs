
using UnityEngine;

public class SaoBang : MonoBehaviour
{
    [Header ("Sao Bang Moveset")]
    [SerializeField] protected float speed;
    GameObject rocket;
    [SerializeField] Transform target;
    Vector3 shot;
    Vector3 dir; 
    float goc;

    [Header("Random Initiate")]
    [SerializeField] Vector2 randomRange;
    [SerializeField] Vector2 randomPoint;

    bool isStartingSequence;
    
   
    private void Start()
    {
        isStartingSequence = false;
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        //Ban theo tau
        /*    shot = rocket.transform.position;
            shot = shot - transform.position; */
        //Ban theo target
        shot = target.transform.position;
        shot = shot - transform.position;
        goc = Mathf.Atan2(shot.y, shot.x);
        dir = new Vector3(Mathf.Cos(goc), Mathf.Sin(goc));
    }

    private void OnEnable() {
        transform.position = RandomPosition();
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
        Move(gameObject.transform, speed);
    }
    //Di chuyen object toi target da tinh toan
    public void Move(Transform obj, float _speed)
    {
        if (Mathf.Abs(goc) > 0)
        {
            Quaternion rotate = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, _speed * Time.deltaTime / 2); ;
        }
        obj.transform.Translate(shot * _speed * Time.deltaTime, relativeTo: Space.World);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(randomPoint, randomRange);
    }
    Vector2 RandomPosition()
    {
        
        float x = Random.Range(randomPoint.x - randomRange.x / 2, randomPoint.x + randomRange.x / 2);
        float y = Random.Range(randomPoint.y - randomRange.y / 2, randomPoint.y + randomRange.y / 2);
        return new Vector2(x, y);
    }
}
