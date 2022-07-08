using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMessage : MonoBehaviour
{
    //�C���[�W
    [SerializeField]
    GameObject ActionButton;
    //�e�L�X�g
    [SerializeField]
    Text ActionText;
    // Start is called before the first frame update
    void Start()
    {
        ActionButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        //���͈̔͂ɓ�������{�^���C���[�W�ƃe�L�X�g��\��
        if (collider.gameObject.name == "Door")//�h�A�̎�
        {
            ActionButton.SetActive(true);
            ActionText.text = "����";
        }
        else if(collider.gameObject.name == "Guide")//�ē��l
        {
            ActionButton.SetActive(true);
            ActionText.text = "�b��";
        }
    }
    //��������\����؂�
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            ActionButton.SetActive(false);
        }
    }
}
