using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private TMP_Text actorText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float typewriterSpeedInSeconds = 0.05f;

    private DialogueData currentDialogue;
    private int currentDialogueIndex = 0;

    public static DialogueManager Singleton;


    void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Open()
    {
        container.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Close()
    {
        container.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartDialogue(DialogueData dialogueInfo)
    {
        currentDialogue = dialogueInfo;
        Open();
        currentDialogueIndex = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        StopAllCoroutines();
        StartCoroutine(TypewriterEffect());
    }

    private IEnumerator TypewriterEffect()
    {
        DialogueInfo dialogueInfo = currentDialogue.dialogueInfo[currentDialogueIndex];
        actorText.SetText(dialogueInfo.actor);
        dialogueText.SetText("");

        foreach(char c in dialogueInfo.dialogue)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typewriterSpeedInSeconds);
        }

    }

    public void NextDialogue()
    {
        currentDialogueIndex++;

        if(currentDialogueIndex >= currentDialogue.dialogueInfo.Length)
        {
            Close();
            return;
        }

        UpdateUI();

    }
}



[System.Serializable]
public struct DialogueInfo
{
    public string actor;
    public string dialogue;
    //public Sprite actorPortrait;
    //Choices
}