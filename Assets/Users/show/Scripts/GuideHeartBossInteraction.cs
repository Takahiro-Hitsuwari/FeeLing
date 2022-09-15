using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GuideHeartBossInteraction : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Animator fadeOutAnim;
    private LevelLoader levelLoader;
    
    public GuideDialogueTrigger dialogeTrigg;
    public GuideDialogueManager dialogeManag;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();   
    }
    public void Conversation(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (button.gameObject.activeSelf)
            {
                dialogeTrigg.TriggerDialogue();
            }
            else if (continueButton.gameObject.activeSelf && !button.gameObject.activeSelf)
            {
                dialogeManag.DisplayNextSentence();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boss")
        {
            button.gameObject.SetActive(true);
        }
        else if(other.gameObject.tag == "bossDoor")
        {
            levelLoader.LoadNextLevel();
        }
    }

    IEnumerator ToNextLevel()
    {
        fadeOutAnim.SetTrigger("in");

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boss")
        {
            button.gameObject.SetActive(false);
        }
    }
}
