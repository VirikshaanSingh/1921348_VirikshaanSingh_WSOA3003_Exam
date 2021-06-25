using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchOut : MonoBehaviour
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
            StartCoroutine(DoTask());
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

    IEnumerator DoTask()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2f);
    }
}
