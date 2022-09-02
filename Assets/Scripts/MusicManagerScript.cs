using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    public AudioClip startscenebgm;
    public AudioClip joybgm;
    public AudioClip map3Bgm;
    public AudioClip rakuBgm;
    public AudioClip Map5Bgm;
    public AudioClip ikaribgm;
    private AudioSource aus;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        aus = GetComponent<AudioSource>();
        playAudio(startscenebgm);
    }


    public void stopAudio()
    {
        aus.Stop();
    }
    public void playAudio(AudioClip audioclip)
    {
        stopAudio();

        aus.clip = audioclip;
        aus.Play();
    }

}
