using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealSkill : Skill
{
    PlayerStats stats;
    public override void Activate(GameObject parent)
    {
     stats = parent.GetComponent<PlayerStats>();
        if(stats.playerStats.Hp < stats.playerStats.Maxhp)
        {
            stats.AddBP();
        }
    }

    public override void Deactivate(GameObject parent)
    {
     
    }
}
