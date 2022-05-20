using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum State
{
    COOLDOWN,
    ALERT,
    INGAME
}
public class Attack : ScriptableObject
{
    [HideInInspector]
    public float timer;
    public float cooldown;
    public float cooldownAlert;
    public float duration;
    public string name;
    [Range(0, 5)]
    public float precision;
    public GameObject alertOutline;
    public GameObject AttackPrefab;



    public State state;

    public virtual void Alert(GameObject parent) { }



    public virtual void Activate(GameObject parent) { }



    public virtual void Deactivate(GameObject parent) { }




}