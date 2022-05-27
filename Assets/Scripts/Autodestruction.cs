using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruction : MonoBehaviour
{
    public float autodistructionTime;
    private float timer;

    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        if (timer < autodistructionTime)
            timer += Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
