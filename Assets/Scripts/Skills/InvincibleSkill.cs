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
        parent.GetComponent<PlayerInteraction>().invincible = true;
    }

    public override void Deactivate(GameObject parent)
    {
        parent.GetComponent<Animator>().ResetTrigger("invincibleSkill");
        parent.GetComponent<PlayerInteraction>().invincible = false;
    }
}
