using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BarrierScript : MonoBehaviour
{
    float timer;
    int consecutive = 0;
    public float interval;
    StageMovement stageSpeed;
    public Sprite circleSprite;
    private Image pressGameObject;
    //private LevelLoader levelLoader;

    void Start()
    {
        stageSpeed = GameObject.Find("MapParent").GetComponent<StageMovement>();    
        pressGameObject = GameObject.Find("pressImage").GetComponent<Image>();
        //levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        if( stageSpeed.speed <= 0)
        {
            if(!pressGameObject.enabled)
            {
                pressGameObject.enabled = true;
                pressGameObject.sprite = circleSprite;
            }
                
            if (Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                if (timer < interval)
                {
                    consecutive++;
                    timer = 0;
                }
                else
                {
                    consecutive = 1;
                    timer = 0;
                }
            }
        }
        if(consecutive == 10)
        {
            //barriar‚ðÁ‚·ˆ—‚ð‚±‚±‚É
            pressGameObject.enabled = false;

            //levelLoader.LoadSpecificScene(2);

            Destroy(this.gameObject);//Test
        }
    }
}
