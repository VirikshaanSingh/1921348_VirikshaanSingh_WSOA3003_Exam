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
    public int maxIndex;
    public Transform[] movePoints;
    public Timer timer;
    Rigidbody2D bossRB;
    private Vector2 movement;
    private int movePointIndex;
    private float waitTime;

    private void Start()
    {
        movePointIndex = 0;
        bossRB = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
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
                transform.position = Vector2.MoveTowards(transform.position, movePoints[movePointIndex].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, movePoints[movePointIndex].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        movePointIndex += 1;
                        waitTime = startWaitTime;

                        if (movePointIndex >= maxIndex)
                        {
                            movePointIndex = 0;
                        }
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
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(5f);
    }
}