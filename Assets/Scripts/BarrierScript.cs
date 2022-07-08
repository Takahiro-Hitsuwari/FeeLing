using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BarrierScript : MonoBehaviour
{
    float timer;
    int consecutive = 1;
    public float interval;
    StageMovement stageSpeed;
    public Sprite circleSprite;
    private Image pressGameObject;
    private GameObject barrier;
    private bool decreasing;
    //private LevelLoader levelLoader;

    void Start()
    {
        barrier = GameObject.Find("PlayerBarrier");
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
            if (timer < interval)
            {
                if (Gamepad.current.buttonEast.wasPressedThisFrame)
                {
                    consecutive++;
                    decreasing = false;
                    StartCoroutine(PlayerBarrierIncrease(0.5f));
                    timer = 0;
                }   
            }
            else
            {
                consecutive = 1;
                if(!decreasing)
                StartCoroutine(PlayerBarrierDecrease());
                timer = 0;
            }
           
        }
        if(consecutive == 10)
        {
            //barriar‚ðÁ‚·ˆ—‚ð‚±‚±‚É
            pressGameObject.enabled = false;

            //levelLoader.LoadSpecificScene(2);

            Destroy(this.gameObject);//Test
        }
        IEnumerator PlayerBarrierIncrease(float increment)
        {
            float startings = barrier.transform.localScale.x;
            while (barrier.transform.localScale.x < startings + increment)
            {
                if (decreasing)
                    break;
                barrier.transform.localScale = Vector3.Lerp(barrier.transform.localScale, barrier.transform.localScale + new Vector3(increment, increment, increment), 2.5f * Time.deltaTime);
                yield return 0;
            }
        
        }

        IEnumerator PlayerBarrierDecrease()
        {
            decreasing = true;
            while (barrier.transform.localScale.x > 0.001f)
            {
                if (!decreasing)
                    break;
                barrier.transform.localScale = Vector3.Lerp(barrier.transform.localScale, Vector3.zero, 5f * Time.deltaTime);
                yield return 0;
            }

        }

    }
}
