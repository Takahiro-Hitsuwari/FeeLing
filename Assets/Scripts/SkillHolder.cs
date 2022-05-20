using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SkillHolder : MonoBehaviour
{
    public Skill [] skills;
    PlayerInput playerInput;
    bool isUpPressed;

    private void Awake()
    {
        playerInput = new PlayerInput();

    }

    public void Skill1Button(InputAction.CallbackContext context)
    {
        isUpPressed = context.ReadValueAsButton();
    }

    void Update()
    {
     foreach (Skill s in skills)
        {
            GameObject img = GameObject.FindGameObjectWithTag(s.tag);

            if (!s.active)
            {
                if (s.cooldown < s.cooldownTime)
                {
                    s.cooldown += Time.deltaTime;
                    img.GetComponent<Image>().fillAmount = s.cooldown / s.cooldownTime;

                }
                else
                {
                    if (isUpPressed)
                    {
                        print("Activating skill: " + s.name);
                        s.Activate(this.gameObject);
                        s.active = true;
                        s.cooldown = 0;
                        img.GetComponent<Image>().fillAmount = 0;
                    }

                }
                if (s.cooldown > s.cooldownTime)
                    s.cooldown = s.cooldownTime;
            }
            else
            {
                if (s.duration_cooldown > 0)
                    s.duration_cooldown -= Time.deltaTime;
                else
                {
                    print("Deactivating skill: " + s.name);
                    s.Deactivate(this.gameObject);
                    s.active = false;
                    s.duration_cooldown = s.duration;
                    img.GetComponent<Image>().fillAmount =0;

                }
            }
            
        }
    }
}
