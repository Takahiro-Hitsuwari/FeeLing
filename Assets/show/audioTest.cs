using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager; //�T�E���h�}�l�[�W���[
    
    
    
    void Update()
    {
         
        if (Input.GetMouseButtonDown(0)) //���N���b�N
        {
            soundManager.Play("a"); //�T�E���h�}�l�[�W���[���g�p���Č��ʉ��Đ�
        }
        if (Input.GetMouseButtonDown(1)) //�E�N���b�N
        {
            soundManager.Play(""); //�T�E���h�}�l�[�W���[���g�p���Č��ʉ��Đ�
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            soundManager.Play("C");
        }
    }
}