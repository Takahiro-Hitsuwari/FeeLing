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
    public Stats playerStats = new Stats();
    public GameObject[] bodyparts;
    public ParticleSystem playerDeathEffect;
    public EventSystem evsys;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    void Update()
    {
        if(playerStats.Hp == 0)
        {
            levelLoader.RetryScreen();
            transform.gameObject.SetActive(false);
            playerDeathEffect.Play();
            //StartCoroutine(Getbutton());

        }
    }

    
    public void DestroyBP()
    {
        bodyparts[playerStats.Maxhp - playerStats.Hp].gameObject.SetActive(false);
        playerStats.Hp --;
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
