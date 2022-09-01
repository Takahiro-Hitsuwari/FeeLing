using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InvincibleSkill : Skill
{
    PlayerStats stats;
    public override void Activate(GameObject parent)
    {
        parent.GetComponent<Animator>().SetTrigger("invincibleSkill");
        parent.GetComponent<PlayerInteraction>().StartCoroutine(parent.GetComponent<PlayerInteraction>().Invulnerability());
    }

    public override void Deactivate(GameObject parent)
    {
       
    }
}
