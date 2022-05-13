using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attackholder : MonoBehaviour
{
    public Attack[] attacks;
    public GameObject player;




    private void Start()
    {
        foreach (Attack a in attacks)
        {
            a.timer = 0;
            a.state = State.COOLDOWN;

        }
    }
    void Update()
    {
        foreach (Attack a in attacks)
        {
            switch (a.state)
            {
                case State.COOLDOWN:
                    if (a.timer < a.cooldown)
                        a.timer += Time.deltaTime;
                    else
                    {
                        a.timer = 0;
                        a.state = State.ALERT;
                        a.Alert(gameObject);
                    }
                    break;
                case State.ALERT:
                    if (a.timer < a.cooldownAlert)
                        a.timer += Time.deltaTime;
                    else
                    {
                        a.timer = 0;
                        a.state = State.COOLDOWN;
                        a.Activate(gameObject);
                    }
                    break;
            }
        }
    }



}