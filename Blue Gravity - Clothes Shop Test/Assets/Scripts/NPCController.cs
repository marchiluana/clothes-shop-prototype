using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private NPC npcData;
    [SerializeField] private Dialogue dialogue;

    private int index;
    private bool playerIsClose;

    private void OnEnable()
    {
        dialogue.Setup(npcData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            dialogue.FinishDialogue();
        }
    }
}

