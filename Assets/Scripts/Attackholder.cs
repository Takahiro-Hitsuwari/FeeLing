using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attackholder : MonoBehaviour
{
    [System.Serializable]
    public enum AttackType
    {
        ��_��,
        ��_�Ԑ���,
        ��_�Ƃ�,
        �{_�t�@�C���[�E�F�[�u,
        �{_���e�I,
        �{_�Β�,
        �{_�n��,
        ��_�X�P�[�g,
        ��_�u���U�[�h,
        ��_�N���X�^��,
        ��_�N���X�^���A�[�`,
        �y_�s�A�m,
        �y_�r�Ԃ鉹�y��,
        �y_����,
        �y_

    }

    [System.Serializable]
    public class kougeki
    {
        public AttackType type { get; set; }
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
    public List<kougeki> attackList = new List<kougeki>();
    private void Start()
    {
        LoadInspectorData();
        foreach(kougeki k in attackList)
        {
            k.alertTimer = 0;
        }

    }
    void Update()
    {
        timer += Time.deltaTime;

        foreach (kougeki k in attackList)
        {
            if (k.attack != null)
            {
                if (timer >= k.time && !k.active)
                {
                    k.active = true;
                    k.attack.Alert(this.gameObject,k);
                }
            }
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

    public void AssignAttack(kougeki k)
    {
        switch (k.type)
        {
            case (Attackholder.AttackType.��_�Ƃ�):
                k.attack = defaultAttacks[0];
                break;
            case (Attackholder.AttackType.��_��):
                k.attack = defaultAttacks[1];
                break;
            case (Attackholder.AttackType.��_�Ԑ���):
                k.attack = defaultAttacks[2];
                break;
                    case (Attackholder.AttackType.�{_�Β�):
                k.attack = defaultAttacks[3];
                break;
        }
    }

    public void LoadInspectorData()
    {
        int i = 0;
        string xtype = PlayerPrefs.GetString("type_" + i);

        while (xtype != null && xtype != "")
        {
            xtype = PlayerPrefs.GetString("type_" + i);
            foreach (AttackType a in (AttackType[])Enum.GetValues(typeof(AttackType)))
            {
                if(xtype == a.ToString())
                {
                    if (attackList.Count <= i)
                        attackList.Add(new kougeki());

                    attackList[i].type = a;
                    attackList[i].time = PlayerPrefs.GetFloat("time_" + i);
                    AssignAttack(attackList[i]);
                    break;
                }

            }
          
            i++;
        }

        while (attackList.Count > i)
        {
            attackList.Remove(attackList[i]);
        }
    }

}