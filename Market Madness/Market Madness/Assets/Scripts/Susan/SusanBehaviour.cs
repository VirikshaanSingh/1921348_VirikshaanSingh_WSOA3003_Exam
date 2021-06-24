using System;
using UnityEngine;

public class SusanBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float range;
    public float speed;
    Rigidbody2D susanRB;
    private Vector2 movement;

    private void Start()
    {
        susanRB = GetComponent<Rigidbody2D>();
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
            Patrol();
        }

        CatchPlayer();
    }

    void MoveSusan (Vector2 direction)
    {
        susanRB.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void Patrol()
    {
        susanRB.velocity = Vector2.zero;//fix, make her patrol
    }

    void CatchPlayer()
    {
        
    }
}
