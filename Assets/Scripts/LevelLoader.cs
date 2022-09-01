using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator retryAnimation;
    private  MusicManagerScript audiomanager;
    public SoundEffect soundEffect;
    public GameObject RetryButton;
    public GameObject QuitButton;
    public byte retries = 5;
    public TextMeshProUGUI textretry;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audiomanager = GetComponent<MusicManagerScript>(); 
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
        retryAnimation.SetTrigger("Start");
        EventSystem evs = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        if (retries <= 0)
        {
            RetryButton.GetComponent<Button>().enabled = false;
            evs.SetSelectedGameObject(null);
            evs.SetSelectedGameObject(QuitButton);
            return;
        }
        else
        {
            evs.SetSelectedGameObject(null);
            evs.SetSelectedGameObject(RetryButton);
        }
    }

    public void RetryLevel()
    {
        retries--;
        textretry.text = retries.ToString();
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
        retries = 5;
        yield return new WaitForSeconds(1f);

        Application.Quit(); 
    }
    void Cheat(InputAction.CallbackContext context)
    {
        LoadNextLevel();
    }
    public void toMainMenu()
    {
        retryAnimation.SetTrigger("End");
        StartCoroutine(LoadLevel(0));
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

            case ("Map1"):
                audiomanager.playAudio(audiomanager.joybgm);
                break;
            case ("Map2"):
                audiomanager.playAudio(audiomanager.ikaribgm);
                break;
            case ("Map3"):
                audiomanager.playAudio(audiomanager.ikaribgm);
                break;
            case ("Map4"):
                audiomanager.playAudio(audiomanager.joybgm);
                break;
            case ("Map5"):
                audiomanager.playAudio(audiomanager.ikaribgm);
                break;
            case ("Map1Boss"):
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;
            case ("Map2Boss"):
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;
            case ("Map3Boss"):
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;
            case ("Map4Boss"):
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;
            case ("Map5Boss"):
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;
            default:
                audiomanager.playAudio(audiomanager.startscenebgm);
                break;

        }
        transition.SetTrigger("End");
    }

    IEnumerator RetryLevelCo()
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        
        retryAnimation.SetTrigger("End");   

        yield return new WaitForSeconds(0.5f); //checking right away would still return the old scene 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        transition.SetTrigger("End");
    }
}
