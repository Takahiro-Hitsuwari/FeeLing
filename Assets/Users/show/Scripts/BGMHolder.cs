using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGMHolder : MonoBehaviour
{
   public AudioClip audioClip;
    private GameObject lvlLoader;
    private LevelLoader levelLoader;
    AudioSource audioSource;
    private MusicManagerScript AM;
    [SerializeField]
    private Button RetryButton;
    private bool isStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        lvlLoader = GameObject.Find("LevelLoader");
        levelLoader = lvlLoader.GetComponent<LevelLoader>();
        audioSource = lvlLoader.GetComponent<AudioSource>();
        AM = lvlLoader.GetComponent<MusicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RetryButton.IsActive() == true && isStopped == false)
        {
            audioClip = audioSource.clip;
            audioSource.Stop();
            isStopped = true;
        }
    }

   public void PlayBGM()
    {
        Debug.Log(audioClip.name);
        StartCoroutine(ReplayBGM());
    }

    IEnumerator ReplayBGM()
    {
        yield return new WaitForSeconds(1.5f);
        AM.playAudio(audioClip);
        isStopped = false;
    }
}
