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
    public bool infiniteMove;
    private LevelLoader levelLoader;
    public float stopingSpeed;
    private float sizeWholeMap = 0;
    public int N_ofmaps;
    public Image ProgressImage;
    private float progressImageSize;
    public GameObject heartImage;
    private float heartStartPos;
    public GameObject Player;
    private float startingSpeed;
    [Space]
    [Header("TUTORIAL")]
    public bool tutorial;
    public bool spawnTutorialAttack;
    [Range(0f, 3f)]
    public byte unlockedSkill;


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
    IEnumerator SlowDown(bool o)
    {
        if (o)
        {
            while (speed > 0)
            {
                speed -= Time.deltaTime * 25;
                yield return null;
            }
        }
        else
        {
            while (speed < 20)
            {
                speed += Time.deltaTime * 25;
                yield return null;
            }
        }
    }
    IEnumerator AnimSkill(GameObject usk)
    {
        while (true)
        {
            while (usk.transform.localScale.x < 1.2f)
            {
                usk.transform.localScale += Vector3.one * 0.1f * Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.25f);
            while (usk.transform.localScale.x > 1f)
            {
                usk.transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator FadeIn(bool o,float val,Image img )
    {
      
        Color c = img.color;

        if (o)
        {
            while (img.color.a < val)
            {
                c.a += 0.005f;
                img.color = c;
                yield return null;
            }
        }
        else
        {
            while (img.color.a > 0f)
            {
                c.a -= 0.005f;
                img.color = c;
                yield return null;
            }
        }
    }
   
    public IEnumerator TutorialCompleted()
    {
        Image fadeinpanel = ProgressImage.transform.parent.transform.parent.transform.parent.GetChild(1).GetComponent<Image>();
        StartCoroutine(FadeIn(false,0,fadeinpanel));
        StartCoroutine(SlowDown(false));
        yield return new WaitForSeconds(3);
        Debug.Log("TutorialCompleted");
        ProgressImage.transform.parent.transform.parent.transform.parent.GetChild(1).gameObject.transform.SetAsLastSibling();
        fadeinpanel = ProgressImage.transform.parent.transform.parent.transform.parent.GetChild(ProgressImage.transform.parent.transform.parent.transform.parent.childCount -1).GetComponent<Image>();
        StartCoroutine(FadeIn(true, 1f,fadeinpanel));
        yield return new WaitForSeconds(1);
        levelLoader.Tutorials[unlockedSkill] = true;
        StartCoroutine(levelLoader.RetryLevelCo());
        
        

    }
    IEnumerator Tutorial()
    {
        infiniteMove = true;
        Player.GetComponent<HeartMovement>().canMove = false;
        Image fadeinpanel = ProgressImage.transform.parent.transform.parent.transform.parent.GetChild(1).GetComponent<Image>();
        ProgressImage.gameObject.SetActive(false);
        if (spawnTutorialAttack)
        {
            yield return new WaitForSeconds(2);
            GameObject.Find("AttackManager").GetComponent<Attackholder>().SingeAttack(true);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeIn(true,0.8f,fadeinpanel));
        StartCoroutine(SlowDown(true));
        GameObject tutorialSkill = new GameObject();
        switch(unlockedSkill)
        {
            case 0:
                tutorialSkill = GameObject.FindGameObjectWithTag("HealSkill");
                break;
            case 1:
                tutorialSkill = GameObject.FindGameObjectWithTag("Impulse");
                break;
            case 2:
                tutorialSkill = GameObject.FindGameObjectWithTag("SlowSkill");
                break;
            case 3:
                tutorialSkill = GameObject.FindGameObjectWithTag("invincibleSkill");
                break;
        }

        StartCoroutine(AnimSkill(tutorialSkill));
    }
    void Start()
    {
       
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        if (levelLoader.Tutorials[unlockedSkill] == true)
        {
            tutorial = false;
        }
        sizeMesh = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
        if (tutorial)
        {
           StartCoroutine(Tutorial());
        }
        if (!infiniteMove)
        { 
         startingSpeed = speed;
        sizeMesh = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;           
        progressImageSize = ProgressImage.GetComponent<RectTransform>().rect.width;
        heartStartPos = heartImage.transform.localPosition.x;
      }
        startingPos = -sizeMesh;
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
        if (Player.GetComponent<PlayerStats>().dead)
            return;

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

                    //Player.GetComponent<SkillHolder>().canUseSkills = false;
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

