using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public MusicManagerScript audiomanager;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public void PreviousGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));

    }

    public void RetryScreen()
    {
        transition.SetTrigger("Start");
    }

    public void RetryLevel()
    {
        StartCoroutine(RetryLevelCo());
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameScreen());
    }
       
    public void LoadSpecificScene(int num)
    {
        StartCoroutine(LoadLevel(num));
    }
    
    
    
    IEnumerator ExitGameScreen()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        Application.Quit(); 
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f); //checking right away would still return the old scene 
        audiomanager.stopAudio();
        
        switch (SceneManager.GetActiveScene().name)
        {

            case ("MainGame"):
                audiomanager.playAudio(audiomanager.joybgm);
                break;

        }
        transition.SetTrigger("End");
    }

    IEnumerator RetryLevelCo()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
