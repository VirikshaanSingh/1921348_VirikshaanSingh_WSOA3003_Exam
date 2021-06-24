using UnityEngine;

public class TempTasks : MonoBehaviour
{
    public bool interactable;
    public GameManager gameManager;

    void Start()
    {
        interactable = false;
    }

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            DoTask();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            interactable = false;
        }
    }

    public void DoTask()
    {
        gameManager.tasksLeft -= 1;
        Destroy(gameObject);
    }
}
