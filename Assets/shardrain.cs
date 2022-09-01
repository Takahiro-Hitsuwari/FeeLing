using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shardrain : MonoBehaviour
{

    public GameObject shardpref;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.1f)
        {
            timer = 0;
            Instantiate(shardpref, transform.position +=new Vector3(Random.Range(-1, 2), 0, 0), shardpref.transform.rotation, this.gameObject.transform);
        }

        
    }
}
