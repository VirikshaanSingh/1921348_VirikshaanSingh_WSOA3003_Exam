using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform player;
    public float range;
    [SerializeField] float catchRange;
    public float speed;
    public float startWaitTime;
    public Transform[] movePoints;
    public Timer timer;
    Rigidbody2D bossRB;
    private Vector2 movement;
    private int randomPoint;
    private float waitTime;

    private void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, movePoints.Length);
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        direction.Normalize();
        movement = direction;

        if (timer.timeLeft <= timer.maxTime/2)
        {
            if (distanceToPlayer < range)
            {
                MoveBoss(movement);
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
        }

        if (distanceToPlayer < catchRange)
        {
            CatchPlayer();
        }   
    }

    void MoveBoss(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void CatchPlayer()
    {
        StartCoroutine(LoseTransition());
    }

    IEnumerator LoseTransition()
    {
        SceneManager.LoadScene(4);
        yield return new WaitForSeconds(5f);
    }
}