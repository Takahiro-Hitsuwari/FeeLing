using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Attack attack;
    private float cooldownTime;
    private float activeTime;

    enum AttackState
        {
        READY,
        ACTIVE,
        COOLDOWN
        }

    AttackState state = AttackState.READY;
    void Update()
    {
        switch (state)
        {
            case AttackState.READY:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    attack.Activate();
                    state = AttackState.ACTIVE;
                    activeTime = attack.activeTime;
                }
                break;
            case AttackState.ACTIVE:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AttackState.COOLDOWN;
                    cooldownTime = attack.cooldownTime;
                }
                break;
            case AttackState.COOLDOWN:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AttackState.READY;
                }
                break;
        }
    }
}
