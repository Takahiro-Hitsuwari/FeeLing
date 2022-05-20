using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpikeAttack : Attack
{
    GameObject alert;
    GameObject attack_model;
    public override void Alert(GameObject parent)
    {
        GameObject player = parent.GetComponent<Attackholder>().player;
        alert = Instantiate(alertOutline, new Vector3(
        player.transform.position.x + Random.Range(-precision, precision),
        0,
        player.transform.position.z + Random.Range(-precision, precision)), new Quaternion(0, 0, 0, 0));
    }

    public override void Activate(GameObject parent)
    {
        if (alert != null)
        {
            attack_model = (Instantiate(AttackPrefab, alert.transform.position, new Quaternion(0, 0, 0, 0)));
            attack_model.AddComponent<Autodestruction>().autodistructionTime = duration;
            Destroy(alert);
        }
    }
}

