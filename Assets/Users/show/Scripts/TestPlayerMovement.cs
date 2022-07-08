using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.aKey.isPressed)
        {
            Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Player.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Keyboard.current.wKey.isPressed)
        {
            Player.transform.Translate(0, 0, speed * Time.deltaTime);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            Player.transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }
}
