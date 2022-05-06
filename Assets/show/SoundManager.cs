using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private float playableDistance = 0.2f;

    //BGM関連
    [System.Serializable]
    public class BGMData
    {
        public bool loop;
        public float volume;
        public AudioClip BGMClip;
        public float playedTime;
    }

    [SerializeField]
    private BGMData[] BGMDatas;

    //SE関連
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public float volume;
        public AudioClip audioClip;
        public float playedTime;
    }

    [SerializeField]
    private SoundData[] soundDatas;

#region SE

    
    private AudioSource[] audioSourceList = new AudioSource[20];

    private void Awake()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name,soundData);
        }
    }
    //使ってないオーディオソースを再利用する
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }

        return null;
    }

    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    public void Play(string name)
    {
        if(soundDictionary.TryGetValue(name,out var soundData))//管理用Dictonaryから、別名で検索
        {
            if(Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;
            soundData.playedTime = Time.realtimeSinceStartup; //次回用に保持
            Play(soundData.audioClip);//あったら再生
        }
        else
        {
            Debug.LogWarning($"{name}は見つかりませんでした");
        }
    }   
#endregion 

#region BGM
    
#endregion
}