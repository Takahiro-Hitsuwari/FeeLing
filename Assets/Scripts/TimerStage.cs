using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerStage : MonoBehaviour
{
    public float stageTime;
    public float timer;
    public TextMeshProUGUI timerText;

    void Update()
    {
        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        timerText.text = string.Format("{0}:{1}", minutes, seconds);
    }
}
