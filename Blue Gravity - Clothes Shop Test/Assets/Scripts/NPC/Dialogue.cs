using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("NPC Info Section")]
    [SerializeField] private string[] npcDialogueText;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcDescription;

    [Header("Dialogue Section")]
    [SerializeField] private TextMeshProUGUI dialogueTextBox;
    [SerializeField] private TextMeshProUGUI ballonTextBox;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private float wordSpeed;

    private int index = 0;

    private void OnEnable()
    {
        dialogueTextBox.text = "";
    }
    void Update()
    {
        if (dialogueTextBox.text == npcDialogueText[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextLine();
            }
        }
    }
    public void Setup(NPC npcData)
    {
        npcDialogueText = npcData.Dialogue;
        npcIcon.sprite = npcData.NPCIcon;
        npcName.text = npcData.NPCName;
        npcDescription.text = npcData.NPCDescription;


    }
    public void StartDialogue()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            FinishDialogue();
        }

        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }

    }

    public void NextLine()
    {
        if (index < npcDialogueText.Length - 1)
        {
            index++;
            dialogueTextBox.text = "";
            StartCoroutine(Typing());
        }

        else
        {
            FinishDialogue();
            ballonTextBox.text = "click on my store to open the catalog and fitting room";
        }
    }

    public void FinishDialogue()
    {
        dialogueTextBox.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public IEnumerator Typing()
    {
        ballonTextBox.text = "press 'spacebar' to continue the dialogue, press 'E' to exit.";
        foreach (char letter in npcDialogueText[index].ToCharArray())
        {
            dialogueTextBox.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }


}
