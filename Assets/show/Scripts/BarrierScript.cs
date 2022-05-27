using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    float timer;
    int consecutive = 0;
    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer * Time.deltaTime;

        if(Keyboard.current[Key.Space].wasThisFrame && StageMovement.speed == 0)
        {
            if(timer < interval)
            {
                consecutive++;
                timer = 0;
            }
            else
            {
                consecutive = 1;
                timer = 0;
            }
        }
        if(consecutive == 10)
        {
            Destroy(this.gameObject);
        }
    }
}
