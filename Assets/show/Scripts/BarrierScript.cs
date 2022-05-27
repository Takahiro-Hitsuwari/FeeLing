using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BarrierScript : MonoBehaviour
{
    /*
    [SerializeField]
    
    public float velocity = 0.0f;
    */
    public GameObject barrier;
    //テスト用*バリアが止まったら
    //private bool isStop = false;
    private bool isGameCleared = false;
    //バリアカウント
    public int barrierCount = 5;

    //アルファ版用***
     public GameObject gameClearObject = null;

    Text gameClearText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
            //テスト用**

            // if (barrier.transform.localPosition.z < 12)
            // {
            //     barrier.transform.Translate(0, 0, velocity * Time.deltaTime);
            // }
            // else
            // {
            //     barrier.transform.position = barrier.transform.position;
            //     isStop = true;
            // }
            //oで破壊

            if (Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                barrierCount--;
               gameClearText = gameClearObject.GetComponent<Text>();
            }

            if (barrierCount == 0)
            {
                Destroy(barrier.gameObject);
                isGameCleared = true;
            }

            if(isGameCleared == true)
            {
                gameClearText.text = "Stage Clear!!";
            }

        
    }
}
