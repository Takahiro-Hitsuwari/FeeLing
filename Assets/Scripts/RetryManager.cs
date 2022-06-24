using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryManager : MonoBehaviour
{
    LevelLoader levload;

    private void Start()
    {
        levload = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void Continue()
    {
        levload.LoadSpecificScene(0);
    }
}
