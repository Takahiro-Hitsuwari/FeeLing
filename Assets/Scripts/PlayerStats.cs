using UnityEngine;

public class Stats
{
    private int hp = 4;
    private int maxhp = 4;
    private float speed = 10f;
    private bool isHit = false;

    public int Hp { get { return hp; } set { hp = value; }}
    public float Speed { get { return speed; } set { speed = value; } }
    
}


public class PlayerStats : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Stats playerStats = new Stats();

    public void Start()
    {
      
    }

    void Update()
    {
        if(playerStats.Hp == 0)
        {
            levelLoader.LoadNextLevel();
        }
    }
}
