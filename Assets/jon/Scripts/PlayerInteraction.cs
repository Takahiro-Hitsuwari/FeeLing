using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LevelLoader levelLoader;

    // Start is called before the first frame update

    int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 4)
        {
            levelLoader.LoadNextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case ("Obstacle1"):
                Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
                count++;
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
