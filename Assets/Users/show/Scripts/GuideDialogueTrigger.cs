using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideDialogueTrigger : MonoBehaviour
{
    public GuideDialogue dialogue;


    public void TriggerDialogue()
    {
        FindObjectOfType<GuideDialogueManager>().StartDialogue(dialogue);
    }
}
