using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attackholder : MonoBehaviour
{
    //[System.Serializable]
    //public enum AttackType
    //{
    //    attack1_1,
    //    attack1_2,
    //    attack1_3,
    //    attack2_1,
    //    attack2_2,
    //    attack2_3,
    //    attack3_1,
    //    attack3_2,
    //    attack3_3,
    //}

    [System.Serializable]
    public class kougeki
    {
        public float time { get; set; }
        public bool active { get; set; }
        public Attack attack { get; set; }
        public bool over { get; set; }
        public float alertTimer { get; set; }
        public GameObject alert { get; set; }

    }

    public List<Attack> defaultAttacks;
    public GameObject player;
    private float timer;
    public GameObject map;
    public bool can_attack;
    [HideInInspector]
    public float time_tick_attack;
    [HideInInspector] 
    public List<kougeki> attackList = new List<kougeki>();
    public StageMovement stagemov;
    private void Start()
    {
        time_tick_attack = 1;
    }
    void Update()
    {
        if (player.GetComponent<PlayerStats>().dead)
                return;

        timer += Time.deltaTime;
        if (stagemov.ProgressImage.fillAmount > 0.9f)
            return;

        if (stagemov.ProgressImage.fillAmount < 0.5f)
        {
            time_tick_attack = 0.9f - stagemov.ProgressImage.fillAmount;
        }
        else if(stagemov.ProgressImage.fillAmount > 0.5f)
        {
            time_tick_attack = stagemov.ProgressImage.fillAmount;
        }
        if(timer > time_tick_attack)
        {
            timer = 0;
            kougeki k = new kougeki();
            k.attack = defaultAttacks[UnityEngine.Random.Range(0, 3)];
            k.active = true;
            k.attack.Alert(this.gameObject, k);
            attackList.Add(k);

        }

        foreach (kougeki k in attackList)
        {
            if(k.active)
            {
                if (k.attack != null)
                {
                    k.alertTimer += Time.deltaTime;
                    if (k.alertTimer >= k.attack.durationAlert && !k.over)
                    {
                        k.over = true;
                        k.alertTimer = 0;
                        k.attack.Activate(this.gameObject,k);
                    }
                }
            }
        }
    }

    //public void AssignAttack(kougeki k)
    //{
    //    switch (k.type)
    //    {
    //        case (Attackholder.AttackType.attack1_1):
    //            k.attack = defaultAttacks[0];
    //            break;
    //        case (Attackholder.AttackType.attack1_2):
    //            k.attack = defaultAttacks[1];
    //            break;
    //        case (Attackholder.AttackType.attack1_3):
    //            k.attack = defaultAttacks[2];
    //            break;
    //        case (Attackholder.AttackType.attack2_1):
    //            k.attack = defaultAttacks[3];
    //            break;
    //        case (Attackholder.AttackType.attack2_2):
    //            k.attack = defaultAttacks[3];
    //            break;
    //        case (Attackholder.AttackType.attack2_3):
    //            k.attack = defaultAttacks[3];
    //            break;
    //    }
    //}

    //public void LoadInspectorData()
    //{
    //    int i = 0;
    //    string xtype = PlayerPrefs.GetString("type_" + i);

    //    while (xtype != null && xtype != "")
    //    {
    //        xtype = PlayerPrefs.GetString("type_" + i);
    //        foreach (AttackType a in (AttackType[])Enum.GetValues(typeof(AttackType)))
    //        {
    //            if(xtype == a.ToString())
    //            {
    //                if (attackList.Count <= i)
    //                    attackList.Add(new kougeki());

    //                attackList[i].type = a;
    //                attackList[i].time = PlayerPrefs.GetFloat("time_" + i);
    //                AssignAttack(attackList[i]);
    //                break;
    //            }

    //        }
          
    //        i++;
    //    }

    //    while (attackList.Count > i)
    //    {
    //        attackList.Remove(attackList[i]);
    //    }
    //}

}