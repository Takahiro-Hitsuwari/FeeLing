using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressText : MonoBehaviour
{
    public int clearedStage = 0; //クリアしたステージのカウント
    Text progressText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        progressText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ProgressUIText();
    }

    void ProgressUIText()
    {
        switch(clearedStage)
        {
            case 1:
                progressText.text = "感情の神:怒を浄化しよう";
                break;
            case 2:
                progressText.text = "感情の神:哀を浄化しよう";
                break ;
            case 3:
                progressText.text = "感情の神:楽を浄化しよう";
                break;
            case 4:
                progressText.text = "憎悪を浄化しよう";
                break;
            default:
                progressText.text = "感情の神:喜を浄化しよう";
                break;



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


