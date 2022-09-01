using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCrystalGate : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        if (player == null)
            return;
        if(Vector3.Distance(player.transform.position,transform.position) < 30)
        {
            GetComponent<Animator>().SetTrigger("close");
        }
    }
}
