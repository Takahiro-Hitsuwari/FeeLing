using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attackholder : MonoBehaviour
{
    public Attack[] attacks;
    public GameObject player;
    private bool isAttacking;
    [Range(0f, 10f)]
    public float Cooldown;
    private float timer;

    private void Start()
    {
        timer = 0;
        isAttacking = false;
        foreach (Attack a in attacks)
        {
            a.timer = 0;
            a.state = State.WAITING;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Cooldown)
            Attack();
        foreach(Attack a in attacks)
        {
            switch (a.state)
            {
                case State.ALERT:
                    if (a.timer < a.cooldownAlert)
                        a.timer += Time.deltaTime;
                    else
                    {
                        a.timer = 0;
                        a.state = State.ALERT;
                        a.Activate(gameObject);
                        a.state = State.WAITING;
                    }
                    break;

            }
        }
    }

    public void Attack()
    {
        timer = 0;
        Attack a = attacks[Random.Range(0, attacks.Length)];
        a.state = State.ALERT;
        a.Alert(gameObject);

    }
}