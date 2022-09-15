using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class GuideText : MonoBehaviour
{
    private GuideDialogue dialogue;
    [SerializeField]
    private GuideDialogue tutrialdialogue;
    //�����̃X�e�[�W���J�����Ă悢���ǂ���
    public bool hatredTrigger = false;
    //�K�C�h�̃e�L�X�g
    [SerializeField]
    private GameObject Guidetxt;
    //�K�C�h�̖��O
    [SerializeField]
    private GameObject guideName;
    //�K�C�h�̃Z���t�ύX�p
    public int guideTextCount = 0;
    //�K�C�h�̃e�L�X�g���t�F�[�h�C���A�E�g����悤
    [SerializeField]
    private Animator textFade;
    //���O���t�F�[�h�C���A�E�g
    [SerializeField]
    private Animator nameFade;
    //�`���[�g���A���e�L�X�g�t�F�[�h�C���A�E�g
    //�e�L�X�g�w�i�̃t�F�[�h�C���A�E�g
    [SerializeField]
    private Animator TextBoxFade;
    //���O�e�L�X�g
    [SerializeField]
    private GameObject NameTxt;
    //�e�L�X�g�w�i
    [SerializeField]
    private GameObject TextBox;
    private TextMeshProUGUI guideTextMeshPro;
    private bool istextFade = false;
    public bool guideEventFlag = true;
    [SerializeField]
    ProgressText ProgressText;
    // Start is called before the first frame update
    void Start()
    {
        dialogue= this.GetComponent<GuideDialogue>();
        guideName.GetComponent<TextMeshProUGUI>().text = dialogue.name;
        guideTextMeshPro = Guidetxt.GetComponent<TextMeshProUGUI>();
        guideTextMeshPro.color = new Color(guideTextMeshPro.color.r, guideTextMeshPro.color.g, guideTextMeshPro.color.b, 0f);
        HatredTrigger();
        if (hatredTrigger == false)
        {
            guideTextMeshPro.text = dialogue.sentences[0];
            StartCoroutine(FirstGuideText());
        }
        else
        {
            //---4�̃X�e�[�W���N���A������v���C���[�����̃|�W�V������---
            guideTextMeshPro.text = dialogue.sentences[10];
            StartCoroutine(TalkWithGuide());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GuideTextDisplay()
    {
        Guidetxt.GetComponent<TextMeshProUGUI>().text = dialogue.sentences[guideTextCount];
    }


    /// <summary>
    /// �G���g�����X�����čŏ��̃C�x���g�p
    /// </summary>
    /// <returns></returns>
    IEnumerator FirstGuideText()
    {
        yield return new WaitForSeconds(1f);
        TextBoxFade.SetBool("TextBox", true);
        yield return new WaitForSeconds(3f);
            textFade.SetBool("Fade", false);
        nameFade.SetBool("Fade", false);
        
        yield return new WaitForSeconds(4f);
        guideTextCount++;
        Guidetxt.GetComponent<TextMeshProUGUI>().text = dialogue.sentences[guideTextCount];
        textFade.SetBool("Fade", true);
        yield return new WaitForSeconds(4f);
        //textFade.SetBool("Fade",false);
        TextBoxFade.SetBool("TextBox", false);
        //yield return new WaitForSeconds(seconds: 2f);
        //nameFade.SetBool("Fade", false);
        textFade.SetBool("Fade",false);
        guideTextCount++;
        yield break;
    }
    /// <summary>
    /// �K�C�h�Ƃ̉�b�C�x���g�p
    /// </summary>
    /// <returns></returns>
    public IEnumerator TalkWithGuide()
    {
       for (int i = 1; i < dialogue.sentences.Count; i++)
        { 
            GuideTextDisplay();
            if (guideTextCount == 2)
            {
                TextBoxFade.SetBool("TextBox", true);
                nameFade.SetBool("Fade", true);                              
                yield return new WaitForSeconds(1f);
                StartCoroutine(DisplayText());
                yield return new WaitForSeconds(3f);

                nameFade.SetBool("Fade", false);       

                yield return new WaitForSeconds(3f);
                //textFade.SetBool("Fade", true);
                yield return new WaitForSeconds(3f);

                //textFade.SetBool("Fade", false);

            }
            else if(guideTextCount == 3)
            {
                yield return new WaitForSeconds(1f);
                StartCoroutine(DisplayText());
                yield return new WaitForSeconds(3f);
            }
            else if (guideTextCount == 4)
            {
                //yield return new WaitForSeconds(3f);
                nameFade.SetBool("Fade", true);
                StartCoroutine(DisplayText());
                //-----�b���A�j���[�V����-----
                yield return new WaitForSeconds(2f);
            }
            else if(guideTextCount == 7)
            {
                StartCoroutine(DisplayText());
                yield return new WaitForSeconds(3f);
                nameFade.SetBool("Fade", false);
                TextBoxFade.SetBool("TextBox", false);
            }
            else if (guideTextCount == 8 && guideEventFlag == true)
            {
                guideEventFlag = false;
            }

            else if (hatredTrigger == true)
            {
                guideEventFlag = true;
                StartCoroutine(DisplayText());
            }
            else if (guideTextCount == 16)
            {
                nameFade.SetBool("Fade", true);
                StartCoroutine(DisplayText());
                yield return new WaitForSeconds(3f);
                nameFade.SetBool("Fade", false);
                guideEventFlag = false;
                yield break;
            }
            else
            {
                //nameFade.SetBool("Fade", true);
                StartCoroutine(DisplayText());
                yield return new WaitForSeconds(3f);
            }
        }
    }

    IEnumerator DisplayText()
    {
        if (guideEventFlag == false)
        {
            textFade.SetBool("Fade", true);
            yield return new WaitForSeconds(3f);
            textFade.SetBool("Fade", false);

        }
        else
        {
            textFade.SetBool("Fade", true);
            yield return new WaitForSeconds(3f);
            textFade.SetBool("Fade", false);
            guideTextCount++;

        }

        yield break;
    }

    void HatredTrigger()
    {
         
        if(ProgressText.clearedStage == 4)
        {
            hatredTrigger = true;
        }
    }
}
