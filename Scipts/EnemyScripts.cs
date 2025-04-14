using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftbound = startPos.x - distance;
        float rightbound = startPos.x + distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if(transform.position.x >= rightbound)
            {
                movingRight = false;
                flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
            if(transform.position.x <= leftbound)
            {
                movingRight=true;
            }
        }
    }

    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
