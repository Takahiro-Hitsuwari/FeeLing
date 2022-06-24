using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    public float durationAlert;
    public float duration;
    public string name;
    [Range(0, 5)]
    public float precision;
    public GameObject alertOutline;
    public GameObject AttackPrefab;
    public bool showAlert;


    public virtual void Alert(GameObject parent,Attackholder.kougeki attack) { }



    public virtual void Activate(GameObject parent, Attackholder.kougeki attack) { }



    public virtual void Deactivate(GameObject parent, Attackholder.kougeki attack) { }




}