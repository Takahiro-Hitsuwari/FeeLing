using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.Playables;

public class DialogueManager : MonoBehaviour
{
    //public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;   
    private int sentenceNumber = 0;
    public GameObject conversationButton;
    public GameObject continueButton;
    private Queue<string> sentences;
    public HeartMovementBossRoom movement;
    public HeartMovementBossRoom movement2;
    public Animator doorAnimation;
    public Animator fadeInOutAnimator;
    public CinemachineFreeLook firstCamera;
    public CinemachineFreeLook camera1;
    public CinemachineFreeLook camera2;
    public CinemachineFreeLook camera3;
    public PlayableDirector director;
    public BoxCollider bossCollider;
    public GameObject player;
    public GameObject player2;
    public ParticleSystem particles;

    public bool entrance = false;


    void Start()
    {
        sentences = new Queue<string>();
        if(entrance )
        {
            director.Play();
        }
        
    }

    public void StartDialogue(Dialogue digalogue)
    {
        conversationButton.SetActive(false);

        movement.canMove = false;

        animator.SetBool("isOpen", true);

        // nameText.text = digalogue.name;

        sentences.Clear();

        foreach(string sentence in digalogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        sentenceNumber++;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        

        if (sentenceNumber > 1)
        {
            StopAllCoroutines();
            StartCoroutine(DisplayText(sentence));
        }
        else
        {
            dialogueText.text = sentence;
            continueButton.SetActive(true);
        }    
        
    }

    IEnumerator DisplayText(string sentence)
    {
        continueButton.SetActive(false);

        animator.SetTrigger("isCloseText");

        yield return new WaitForSeconds(1f);

        dialogueText.text = sentence;

        yield return new WaitForSeconds(1f);

        continueButton.SetActive(true);
    }

    void EndDialogue()
    {
        StartCoroutine(EndDialog());
    }

    IEnumerator EndDialog()
    {
        animator.SetBool("isOpen", false);
        fadeInOutAnimator.SetTrigger("in");

        yield return new WaitForSeconds(2f);

        player.SetActive(false);
        player2.SetActive(true);
        movement2.canMove = false;
        bossCollider.enabled = false;
        firstCamera.VirtualCameraGameObject.SetActive(false);
        camera1.VirtualCameraGameObject.SetActive(true);
        camera2.VirtualCameraGameObject.SetActive(true);
        camera3.VirtualCameraGameObject.SetActive(true);
        if(entrance)
        {
            director.Resume();
        }
        else
        {
            director.Play();
        }
        
        fadeInOutAnimator.SetTrigger("out");
        
        //conversationButton.SetActive(true);
        //sentenceNumber = 0;

        yield return new WaitForSeconds(2f);

        doorAnimation.SetTrigger("open");

        yield return new WaitForSeconds(1.5f);

        particles.Play();

        yield return new WaitForSeconds(6.5f);

        movement2.canMove = true;
    }

    public void stop()
    {
        director.Pause();    
    }
}
