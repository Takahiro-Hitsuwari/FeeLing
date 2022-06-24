using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpikeAttack : Attack
{
    GameObject attack_model;
    Attackholder atkhold;
    public override void Alert(GameObject parent,Attackholder.kougeki Attack)
    {
        atkhold = parent.GetComponent<Attackholder>();
        GameObject player = atkhold.player;
        float posx = player.transform.position.x + Random.Range(-precision, precision);
        if(posx < 3.35f)
            posx = 3.35f;
        else if (posx > 7.5f)
            posx = 7.5f;
        Attack.alert = Instantiate(alertOutline, new Vector3(posx, 0,parent.transform.position.z - Random.Range(10, 20)), new Quaternion(0, 0, 0, 0));

       
    }

    public override void Activate(GameObject parent, Attackholder.kougeki Attack)
    {
        if (Attack.alert != null)
        {
            attack_model = (Instantiate(AttackPrefab, Attack.alert.transform.position, new Quaternion(0, 0, 0, 0)));
            attack_model.AddComponent<Autodestruction>().autodistructionTime = duration;
            attack_model.transform.parent = parent.GetComponent<Attackholder>().map.transform;
            Destroy(Attack.alert);
        }
    }
}

