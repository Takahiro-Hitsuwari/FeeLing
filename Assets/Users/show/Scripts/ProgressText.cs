using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressText : MonoBehaviour
{
    public int clearedStage = 0; //�N���A�����X�e�[�W�̃J�E���g
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
                progressText.text = "����̐_:�{���򉻂��悤";
                break;
            case 2:
                progressText.text = "����̐_:�����򉻂��悤";
                break ;
            case 3:
                progressText.text = "����̐_:�y���򉻂��悤";
                break;
            case 4:
                progressText.text = "�������򉻂��悤";
                break;
            default:
                progressText.text = "����̐_:����򉻂��悤";
                break;



        }
           
    }
    //Stage���N���A������clearedStage��++����֐�
    //(5�܂ő������烊�Z�b�g)
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


