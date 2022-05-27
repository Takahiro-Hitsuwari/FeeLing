using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum State
{
    WAITING,
    ALERT
}
public class Attack : ScriptableObject
{
    [HideInInspector]
    public float timer;
    public float cooldownAlert;
    public float duration;
    public string name;
    [Range(0, 5)]
    public float precision;
    public GameObject alertOutline;
    public GameObject AttackPrefab;
    public bool showAlert;


    public State state;

    public virtual void Alert(GameObject parent) { }



    public virtual void Activate(GameObject parent) { }



    public virtual void Deactivate(GameObject parent) { }




}