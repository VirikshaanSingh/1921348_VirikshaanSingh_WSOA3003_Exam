using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int maxTasks;
    public int tasksLeft;
    public GameObject dialogueBox;
    public GameObject punchBoard;
    public Timer timer;


    void Start()
    {
        tasksLeft = maxTasks;
        dialogueBox.SetActive(false);
        punchBoard.SetActive(false);
    }

    private void Update()
    {
        if (timer.timeLeft <=0 && tasksLeft <= 0)
        {
            punchBoard.SetActive(false);
        }
    }
}
