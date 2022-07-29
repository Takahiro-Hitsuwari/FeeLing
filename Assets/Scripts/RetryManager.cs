using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RetryManager : MonoBehaviour
{
    LevelLoader levload;
    public GameObject continueButton;
    EventSystem evntSys;

 void Awake() {
     evntSys = EventSystem.current;
    
}
    private void Start()
    {
        evntSys.SetSelectedGameObject(null);
        evntSys.SetSelectedGameObject(continueButton);
        levload = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void Continue()
    {
        levload.LoadSpecificScene(0);
    }
}
