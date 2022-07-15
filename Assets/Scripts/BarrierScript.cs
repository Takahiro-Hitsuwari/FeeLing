using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarrierScript : MonoBehaviour
{
    float timer;
    int consecutive = 1;
    public float interval;
    StageMovement stageSpeed;
    private LevelLoader levelLoader;
    public Sprite circleSprite;
    private Image pressGameObject;
    private GameObject barrier;
    private bool decreasing;
    private CameraShake shakeCamera;
    //private LevelLoader levelLoader;
    private float shakeMagnitude = 0.05f;
    private GameObject mainCamera;
    private bool barrierDestroyed = false;

    void Start()
    {
        barrier = GameObject.Find("PlayerBarrier");
        stageSpeed = GameObject.Find("MapParent").GetComponent<StageMovement>();    
        pressGameObject = GameObject.Find("pressImage").GetComponent<Image>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        shakeCamera = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        mainCamera = GameObject.Find("FollowCamera");
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
                if (Gamepad.current.buttonEast.wasPressedThisFrame && !barrierDestroyed)
                {
                    consecutive++;
                    shakeCamera.Shake(0.35f, shakeMagnitude);
                    shakeMagnitude += 0.05f;
                    decreasing = false;
                    StartCoroutine(PlayerBarrierIncrease(0.5f));
                    timer = 0;
                }   
            }
            else
            {
                shakeMagnitude = 0.03f;
                consecutive = 1;
                if(!decreasing)
                StartCoroutine(PlayerBarrierDecrease(2.5f));
                timer = 0;
            }
           
        }
        if(consecutive == 10)
        {
            //barriar‚ðÁ‚·ˆ—‚ð‚±‚±‚É
            pressGameObject.enabled = false;
            if (!decreasing)
                StartCoroutine(PlayerBarrierDecrease(1f));
            barrierDestroyed = true;


            //levelLoader.LoadSpecificScene(2);


            //transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = false;
            Destroy(this.gameObject);//Test


            levelLoader.LoadNextLevel();
            //StartCoroutine(ToBossRoom());
        }


        IEnumerator PlayerBarrierIncrease(float increment)
        {
            float startings = barrier.transform.localScale.x;
            while (barrier.transform.localScale.x < startings + increment)
            {
                if (decreasing)
                    break;
                barrier.transform.localScale = Vector3.Lerp(barrier.transform.localScale, barrier.transform.localScale + new Vector3(increment, increment, increment), 2.5f * Time.deltaTime);
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mainCamera.transform.position + new Vector3(0f,-0.2f,0.3f), 2.5f * Time.deltaTime);
                yield return 0;
            }
        
        }

        IEnumerator PlayerBarrierDecrease(float tmpspeed)
        {
            
            decreasing = true;
            while (barrier.transform.localScale.x > 0.001f)
            {Debug.Log("ffffffffffffffff");
                if (!decreasing)
                    break;
                barrier.transform.localScale = Vector3.Lerp(barrier.transform.localScale, Vector3.zero, 5f * Time.deltaTime);
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, Vector3.zero, tmpspeed * Time.deltaTime);
                yield return 0;
            }

        }

    }
}
