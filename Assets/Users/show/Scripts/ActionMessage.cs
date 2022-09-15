using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActionMessage : MonoBehaviour
{
    [SerializeField]
    private PlayerInput inputActions; 
    [SerializeField]
    GameObject ActionButton;
    [SerializeField]
    Text ActionText;
    [SerializeField]
    private GuideText GuideText;
    private bool isTalking = false;
    public bool canAction = false;
    // Start is called before the first frame update
    void Start()
    {
        ActionButton.SetActive(false);
        ActionText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Display Text and Image when approaching a specific object
        switch (other.gameObject.name)
        {
            case "Door":
                ActionButton.SetActive(true);
                ActionText.enabled = true;
                ActionText.text = "“ü‚é";
                canAction = true;
                break;
            case "Guide":
                if (GuideText.guideEventFlag == false && Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    GuideText.guideTextCount = Random.Range(8, 9);
                    StartCoroutine(GuideText.TalkWithGuide());
                }
                else if (isTalking == false)
                {
                    StartCoroutine(GuideText.TalkWithGuide());
                    isTalking = true;
                }
                break;

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        ActionButton.SetActive(false);
        ActionText.enabled = false;
    }
}
