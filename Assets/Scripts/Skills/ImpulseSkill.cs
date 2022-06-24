using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ImpulseSkill : Skill
{
    PlayerStats stats;
    public override void Activate(GameObject parent)
    {
        stats = parent.GetComponent<PlayerStats>();
        foreach (Collider c in Physics.OverlapSphere(parent.transform.position,10f))
        {
            if(c.gameObject.tag == "Obstacle1")
            {
                Destroy(c.gameObject);
            }
        }

      
    }

    public override void Deactivate(GameObject parent)
    {

    }
}
