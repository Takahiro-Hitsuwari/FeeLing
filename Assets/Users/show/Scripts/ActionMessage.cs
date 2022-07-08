using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMessage : MonoBehaviour
{
    //イメージ
    [SerializeField]
    GameObject ActionButton;
    //テキスト
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
        //一定の範囲に入ったらボタンイメージとテキストを表示
        if (collider.gameObject.name == "Door")//ドアの時
        {
            ActionButton.SetActive(true);
            ActionText.text = "入る";
        }
        else if(collider.gameObject.name == "Guide")//案内人
        {
            ActionButton.SetActive(true);
            ActionText.text = "話す";
        }
    }
    //抜けたら表示を切る
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            ActionButton.SetActive(false);
        }
    }
}
