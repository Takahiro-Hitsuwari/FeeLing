using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager; //サウンドマネージャー

    [SerializeField]
    private AudioClip clip1; //音源データ1

    [SerializeField]
    private AudioClip clip2; //音源データ2

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //左クリック
        {
            soundManager.Play(clip1); //サウンドマネージャーを使用して効果音再生
        }
        if (Input.GetMouseButtonDown(1)) //右クリック
        {
            soundManager.Play(clip2); //サウンドマネージャーを使用して効果音再生
        }
    }
}