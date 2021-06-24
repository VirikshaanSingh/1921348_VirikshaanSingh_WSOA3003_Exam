using UnityEngine;

public class NPCTriggers : MonoBehaviour
{
    public NPC npc;
    public DialogueManager dialogueManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npc.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueManager.EndDialogue();
        }
    }
}
