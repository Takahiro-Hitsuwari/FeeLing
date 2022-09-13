using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu]
public class SlowSkill : Skill
{
    PlayerStats stats;
    StageMovement sm;
    private Volume v;
    WhiteBalance w;
    public override void Activate(GameObject parent)
    {
        v = GameObject.Find("Global Volume").GetComponent<Volume>();
        v.profile.TryGet(out w);
        w.temperature.value = -40;
        sm = GameObject.FindGameObjectWithTag("stage").GetComponent<StageMovement>();
        sm.speed = 10;

    }

    public override void Deactivate(GameObject parent)
    {
        Debug.Log("deactivating slow");
        v = GameObject.Find("Global Volume").GetComponent<Volume>();
        v.profile.TryGet(out w);
        w.temperature.value = 0;
        sm.speed = 20;
    }
}
