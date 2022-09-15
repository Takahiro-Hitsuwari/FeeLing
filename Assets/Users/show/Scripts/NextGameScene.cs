using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextGameScene : MonoBehaviour
{
    LevelLoader LevelLoader;
    [SerializeField]
    ActionMessage action;
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if(action.canAction == true && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            LevelLoader.LoadNextLevel();
        }*/
    }

    
 
}
