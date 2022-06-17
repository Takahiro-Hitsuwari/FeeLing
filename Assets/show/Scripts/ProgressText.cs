using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressText : MonoBehaviour
{
    public int clearedStage = 0; //クリアしたステージのカウント
    TextMeshProUGUI progressText;
    // Start is called before the first frame update
    void Start()
    {
        progressText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ProgressUIText();
    }

    void ProgressUIText()
    {
        if (clearedStage == 4)
        {
            progressText.text = "憎悪を浄化しよう";
        }
        else if (clearedStage == 3)
        {
            progressText.text = "感情の神:楽を浄化しよう";
        }
        else if (clearedStage == 2)
        {
            progressText.text = "感情の神:哀を浄化しよう";
        }
        else if (clearedStage == 1)
        {
            progressText.text = "感情の神:怒を浄化しよう";
        }
        else
        {
            progressText.text = "感情の神:喜を浄化しよう";
        }
    }
    //StageをクリアしたらclearedStageを++する関数
    //(5まで増えたらリセット)
    public void ClearedStageCount()
    {
        if (clearedStage == 5)
        {
            clearedStage = 0;
        }
        else
        {
            clearedStage++;
        }
    }
}


