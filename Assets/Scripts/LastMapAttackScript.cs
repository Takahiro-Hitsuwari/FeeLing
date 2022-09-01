using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMapAttackScript : MonoBehaviour
{
    public GameObject LeftSpawner;
    public GameObject RightSpawner;
    public GameObject blockPref;
    public GameObject map;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2.5f)
        {
            timer = 0;
            int rnd = Random.Range(0, 3);
            switch(rnd)
            {
                case (0):
                    //no spawn
                    break;
                case (1):
                    GameObject cube = Instantiate(blockPref, LeftSpawner.transform); //spawnleft
                    cube.transform.parent = map.transform;
                    break;
                case (2):
                    GameObject cube2 = Instantiate(blockPref, RightSpawner.transform); //spawnright
                    cube2.transform.parent = map.transform;
                    break;
            }    
        }
    }

}
