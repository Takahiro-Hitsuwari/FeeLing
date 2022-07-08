using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMessage : MonoBehaviour
{
    [SerializeField]
    GameObject ActionButton;
    [SerializeField]
    Text ActionText;
    // Start is called before the first frame update
    void Start()
    {
        ActionButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Door")
        {
            ActionButton.SetActive(true);
            ActionText.text = "“ü‚é";
        }
        else if(collider.gameObject.name == "Guide")
        {
            ActionButton.SetActive(true);
            ActionText.text = "˜b‚·";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            ActionButton.SetActive(false);
        }
    }
}
