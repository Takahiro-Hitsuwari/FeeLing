using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LineAttack : Attack
{
    GameObject alert;
    GameObject attack_model;
    public override void Alert(GameObject parent)
    {
        GameObject player = parent.GetComponent<Attackholder>().player;
        alert = Instantiate(alertOutline, new Vector3(parent.transform.position.x,0,parent.transform.position.z), new Quaternion(0, 0, 0, 0));
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