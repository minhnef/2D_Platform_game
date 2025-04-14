using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private float speed;
    private Vector3 target;
    private Transform player;
    void Start()
    {
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            if(target == posA.position)
            {
                target = posB.position;
            }
            else
            {
                target = posA.position;
            }
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(player.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
