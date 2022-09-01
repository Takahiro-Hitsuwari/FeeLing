using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip damage, barrierAttack, barrierDestroy, skillCharge, titleSe;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    public void stopAudio()
    {
        audioS.Stop();
    }
    public void playAudio(AudioClip audioclip)
    {
        stopAudio();

        audioS.clip = audioclip;
        audioS.Play();
    }
}
