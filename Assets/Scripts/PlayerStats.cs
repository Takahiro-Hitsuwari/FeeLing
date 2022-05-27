using System.Collections.Generic;
using UnityEngine;

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
    public LevelLoader levelLoader;
    public LevelLoader retryLevel;
    public Stats playerStats = new Stats();
    public GameObject[] bodyparts;
    public ParticleSystem playerDeathEffect;




    void Update()
    {
        if(playerStats.Hp == 0)
        {
            retryLevel.RetryScreen();
            transform.gameObject.SetActive(false);
            playerDeathEffect.Play();
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
}
