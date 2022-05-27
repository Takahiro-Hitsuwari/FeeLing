using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool gameover = false;
    public GameObject enemy;
    public bool infiniteMove;


    private void InstantiateStage(GameObject stage_pref, ref float startPos)
    {
        GameObject g = Instantiate(stage_pref, new Vector3(0, 0, -startPos), new Quaternion(0, 0, 0, 0), stageContainer.transform);
        g.transform.localPosition = new Vector3(0, 0, -startPos);
        startPos -= sizeMesh;    
        stages.Add(g);
        if(stages.Count > 4)
        {
            Destroy(stages[0].gameObject);
            stages.RemoveAt(0);
        }    
    }

    void Start()
    {
        sizeMesh = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
        startingPos = -sizeMesh;

        //Instantiate the first 3 floor
        for (int i = 0; i < 3; i++)
        {
            InstantiateStage(stagePrefab, ref startingPos);
        }
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
            if (!gameover)
            {
                if (transform.position.z < startingPos + (sizeMesh * 3))
                {
                    if (timemanager.timer < timemanager.stageTime)
                        InstantiateStage(stagePrefab, ref startingPos);
                    else
                    {
                        gameover = true;
                        InstantiateStage(stagedoor, ref startingPos);
                        enemy.GetComponent<Attackholder>().can_attack = false;
                    }
                }

            }
            else
            {
                if (transform.position.z < startingPos + (sizeMesh * 2))
                {
                    if (speed > 0)
                    {
                        speed -= 2f * Time.deltaTime;

                        if (transform.position.z < startingPos + (sizeMesh))
                        {
                            if (speed < 20)
                            {
                                speed += 10f * Time.deltaTime;
                            }
                            if (Camera.main.transform.parent == null)
                                Camera.main.transform.parent = stages[stages.Count - 1].gameObject.transform;
                        }

                    }

                }
            }
        }
        
    }

}
