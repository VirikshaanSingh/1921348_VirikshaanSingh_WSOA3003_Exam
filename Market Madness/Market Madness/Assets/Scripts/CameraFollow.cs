using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 camPosition = Vector3.Lerp(transform.position, playerPosition, speed);
        transform.position = camPosition;
    }

}