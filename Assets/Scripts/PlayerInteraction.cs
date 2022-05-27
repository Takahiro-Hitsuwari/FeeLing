using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerStats playerStats;
    // Start is called before the first frame update

    int count = 0;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case ("Obstacle1"):
                Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
                playerStats.playerStats.Hp -= 1;
                break;
            case ("Obstacle2"):
                Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
                break;
            case ("Obstacle3"):
                Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
                break;
            default:

                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
