using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public float cooldownTime;
    public float cooldown;
    public string name;
    public float duration;
    public float duration_cooldown;
    public bool active;
    public string tag;


    public virtual void Activate(GameObject parent) { }
    public virtual void Deactivate(GameObject parent) { }
    
}
