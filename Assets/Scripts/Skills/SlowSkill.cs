using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowSkill : Skill
{
    PlayerStats stats;
    StageMovement sm;
    public override void Activate(GameObject parent)
    {
        //GameObject[] projectiles =  GameObject.FindGameObjectsWithTag("Obstacle1");
        sm = GameObject.FindGameObjectWithTag("stage").GetComponent<StageMovement>();
        sm.speed -= 10;

    }

    public override void Deactivate(GameObject parent)
    {
        sm.speed += 10;
    }
}
