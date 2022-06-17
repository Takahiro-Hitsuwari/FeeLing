using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressText : MonoBehaviour
{
    public int clearedStage = 0; //�N���A�����X�e�[�W�̃J�E���g
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
            progressText.text = "�������򉻂��悤";
        }
        else if (clearedStage == 3)
        {
            progressText.text = "����̐_:�y���򉻂��悤";
        }
        else if (clearedStage == 2)
        {
            progressText.text = "����̐_:�����򉻂��悤";
        }
        else if (clearedStage == 1)
        {
            progressText.text = "����̐_:�{���򉻂��悤";
        }
        else
        {
            progressText.text = "����̐_:����򉻂��悤";
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


