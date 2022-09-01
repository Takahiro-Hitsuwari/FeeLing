using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerStats playerStats;

    private  LevelLoader levelLoader;
    Animator animator;
    public bool invincible = false;
    public float invicibilityTime = 2.5f;
    public ParticleSystem hitparticle;
    public CameraShake shakeCamera;


    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
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
                    shakeCamera.Shake(0.50f, 0.2f);
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

    public IEnumerator Invulnerability()
    {
        invincible = true;
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(invicibilityTime);
        invincible = false;
    }

}
