using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
