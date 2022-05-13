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
        if (other.gameObject.CompareTag("Obstacle1"))
        {
            Debug.Log("Sphere");
        }
        else if (other.gameObject.CompareTag("Obstacle2"))
        {
            Debug.Log("Cube");
        }
        else if (other.gameObject.CompareTag("Obstacle3"))
        {
            Debug.Log("Cylinder");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
