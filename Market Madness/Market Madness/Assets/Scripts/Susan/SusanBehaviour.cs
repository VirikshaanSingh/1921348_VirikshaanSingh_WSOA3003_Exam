using UnityEngine;

public class SusanBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float range;
    public float speed;
    public float startWaitTime;
    public Transform[] movePoints;
    Rigidbody2D susanRB;
    private Vector2 movement;
    private int randomPoint;
    private float waitTime;

    private void Start()
    {
        susanRB = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, movePoints.Length);
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        direction.Normalize();
        movement = direction;

        if (distanceToPlayer < range)
        {
            MoveSusan(movement);
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoints[randomPoint].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movePoints[randomPoint].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomPoint = Random.Range(0, movePoints.Length);
                    waitTime = startWaitTime;
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }

        CatchPlayer();
    }

    void MoveSusan (Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void CatchPlayer()
    {
        
    }
}
