using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerStats playerStats;

    public LevelLoader levelLoader;
    Animator animator;
    bool invincible = false;
    public float invicibilityTime = 2.5f;


    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!invincible)
        {
            switch (other.gameObject.tag)
            {
                case ("Obstacle1"):
                    //Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
                    playerStats.DestroyBP();
                    StartCoroutine(Invulnerability());
                    break;
                case ("gameClear"):
                    levelLoader.LoadNextLevel();
                    break;
                default:

                    break;
            }
        }
    }

    IEnumerator Invulnerability()
    {
        invincible = true;
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(invicibilityTime);
        invincible = false;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
