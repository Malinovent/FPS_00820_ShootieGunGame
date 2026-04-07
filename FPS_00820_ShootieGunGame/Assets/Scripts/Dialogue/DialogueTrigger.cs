using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData dialogue;

    void Update()
    {
        //Testing
        if(Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    public void Interact()
    {
        DialogueManager.Singleton.StartDialogue(dialogue);
    }
}
