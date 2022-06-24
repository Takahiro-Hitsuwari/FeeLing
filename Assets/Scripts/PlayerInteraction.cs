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
    public ParticleSystem hitparticle;


    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
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
                    hitparticle.Play();
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

}
