using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Stats
{
    private int hp = 4;
    private int maxhp = 4;
    private float speed = 10f;
    private bool isHit = false;

    public int Hp { get { return hp; } set { hp = value; }}
    public float Speed { get { return speed; } set { speed = value; } }
    public int Maxhp { get { return maxhp; } set { maxhp = value; } }

}


public class PlayerStats : MonoBehaviour
{
    private LevelLoader levelLoader;
    public Stats playerStats;
    public GameObject[] bodyparts;
    public ParticleSystem playerDeathEffect;
    public EventSystem evsys;
    public bool dead;


    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        playerStats = new Stats();
        dead = false;

    }

    void Update()
    {
        if(playerStats.Hp == 0)
        {
            levelLoader.RetryScreen();
            transform.gameObject.SetActive(false);
            playerDeathEffect.Play();
            dead = true;
            //StartCoroutine(Getbutton());
        }
    }

    
    public void DestroyBP()
    {
            bodyparts[playerStats.Maxhp - playerStats.Hp].gameObject.SetActive(false);
            playerStats.Hp--;
            levelLoader.soundEffect.playAudio(levelLoader.soundEffect.damage);
    }

    public void AddBP()
    {
        playerStats.Hp++;
        bodyparts[playerStats.Maxhp - playerStats.Hp].gameObject.SetActive(true);   
    }

    //IEnumerator Getbutton()
    //{
    //    yield return new WaitForSeconds(1f);

    //    GameObject butono = GameObject.Find("RetryButton");
    //    evsys.SetSelectedGameObject(butono);

    //}
}
