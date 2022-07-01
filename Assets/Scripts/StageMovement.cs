using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMovement : MonoBehaviour
{
    public GameObject stage;
    public GameObject stagePrefab;
    public GameObject stageContainer;
    private List<GameObject> stages = new List<GameObject>();
    private float startingPos;
    public GameObject stagedoor;
    float sizeMesh;
    public float speed;
    public TimerStage timemanager;
    private bool slowingDown = false;
    public GameObject enemy;
    public bool infiniteMove;
    public float stopingSpeed;
    private float sizeWholeMap = 0;
    public int N_ofmaps;
    public Image ProgressImage;
    private float progressImageSize;
    public GameObject heartImage;
    private float heartStartPos;
    public GameObject Player;
    private float startingSpeed;


    private void InstantiateStage(GameObject stage_pref, ref float startPos)
    {
        GameObject g = Instantiate(stage_pref, new Vector3(0, 0, -startPos), new Quaternion(0, 0, 0, 0), stageContainer.transform);
        g.transform.localPosition = new Vector3(0, 0, -startPos);
        startPos -= sizeMesh;
       
       
        if (infiniteMove)
        {
            stages.Add(g);
            if (stages.Count > 4)
            {
                Destroy(stages[0].gameObject);
                stages.RemoveAt(0);
            }
        }
    }

    void Start()
    {
        startingSpeed = speed;
        sizeMesh = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
        startingPos = -sizeMesh;
        progressImageSize = ProgressImage.GetComponent<RectTransform>().rect.width;
        heartStartPos = heartImage.transform.localPosition.x;

        //Instantiate x floor
        for (int i = 0; i < N_ofmaps -1; i++)
        {
            InstantiateStage(stagePrefab, ref startingPos);
            sizeWholeMap += sizeMesh;

        }
        sizeWholeMap += sizeMesh;
        InstantiateStage(stagedoor, ref startingPos);

    }

    void Update()
    {
        if (infiniteMove)
        {
            stage.transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (transform.position.z < startingPos + (sizeMesh * 3))
            {
                InstantiateStage(stagePrefab, ref startingPos);
            }
        }
        else
        {
            stage.transform.Translate(Vector3.back * speed * Time.deltaTime);

            //progressMap
            ProgressImage.fillAmount = (stage.transform.position.z / (-sizeWholeMap - sizeMesh + 5f));


            float relativePos = (progressImageSize - 10) * ProgressImage.fillAmount;
            heartImage.transform.localPosition =new Vector3(heartStartPos + relativePos, heartImage.transform.localPosition.y, heartImage.transform.localPosition.z);
           

            if(stage.transform.position.z < -sizeWholeMap)
            {
                if (!slowingDown)
                {
                    if (speed != startingSpeed)
                        speed = startingSpeed;

                    Player.GetComponent<SkillHolder>().canUseSkills = false;
                    enemy.GetComponent<Attackholder>().can_attack = false;
                    slowingDown = true;
                }
                else if (speed > 0)
                {
                    speed -= stopingSpeed * Time.deltaTime;

                }
            }
        }    

     }

}

