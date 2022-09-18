using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SkillHolder : MonoBehaviour
{
    enum pressedButton
    {
        NULL,
        UP,
        RIGHT,
        LEFT,
        DOWN
    }

    public Skill [] skills;
    PlayerInteraction playerinter;
    pressedButton pressButton = pressedButton.NULL;
    private Skill activatedSkill;
    public bool canUseSkills = true;
    public Sprite[] SkillUiSprites;
    public ParticleSystem healEffect;
    private void Awake()
    {
        playerinter = GetComponent<PlayerInteraction>();

    }
    private void Start()
    {
        foreach(Skill skill in skills)
        {
            skill.cooldown = skill.cooldownTime;
            skill.active = false;
        }
    }


    public void Skill1Button(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            pressButton = pressedButton.UP;
    }
    public void Skill2Button(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            pressButton = pressedButton.LEFT;
    }
    public void Skill3Button(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            pressButton = pressedButton.DOWN;
    }
    public void Skill4Button(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            pressButton = pressedButton.RIGHT;
    }

    void Update()
    {
        if (!canUseSkills)
            return;



     foreach (Skill s in skills)
        {
            GameObject img = GameObject.FindGameObjectWithTag(s.tag);
            if (img == null)
                return;

            if (s.active)
            {
                if(s.duration < s.duration_cooldown)
                {
                    s.duration += Time.deltaTime;
                }
                else if(s.active)
                {
                    s.Deactivate(this.gameObject);
                    s.active = false;
                    s.duration = 0;
                    if (img.GetComponent<Image>().sprite != SkillUiSprites[0])
                        img.GetComponent<Image>().sprite = SkillUiSprites[0];

                    if (activatedSkill != null)
                    {
                        activatedSkill.active = false;
                        activatedSkill.duration = 0;
                        activatedSkill = null;
                    }
                }
            }
            else if (s.cooldown < s.cooldownTime && !s.active)
            {
                s.cooldown += Time.deltaTime;
                if (img.GetComponent<Image>().sprite != SkillUiSprites[1])
                    img.GetComponent<Image>().sprite = SkillUiSprites[1];

                if (s.cooldown > s.cooldownTime)
                    s.cooldown = s.cooldownTime;

            }
            else if(s.button.ToString() == pressButton.ToString() && s.button != Skill.Button.NULL)
            {
                activatedSkill = s;
                if(s.tag == "HealSkill")
                {
                    healEffect.Play();
                }
                else if(s.tag == "Impulse")
                {

                }
                else if (s.tag == "invincibleSkill")
                {

                }

                if (GameObject.Find("MapParent").GetComponent<StageMovement>().tutorial && (int)s.button == GameObject.Find("MapParent").GetComponent<StageMovement>().skilnum)
                {
                    StartCoroutine(GameObject.Find("MapParent").GetComponent<StageMovement>().TutorialCompleted());
                }
            }
            else
            {
                if (img.GetComponent<Image>().sprite != SkillUiSprites[0])
                {
                    img.GetComponent<Image>().sprite = SkillUiSprites[0];
                    LevelLoader ung = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
                    ung.soundEffect.playAudio(ung.soundEffect.skillCharge);
                }
            }

            if (activatedSkill != null && !activatedSkill.active)   
            if (activatedSkill != null && !activatedSkill.active)
            {
                print("Activating skill: " + s.name);
                activatedSkill.Activate(this.gameObject);
                activatedSkill.active = true;
                activatedSkill.cooldown = 0;
                 

                pressButton = pressedButton.NULL;

                img.GetComponent<Image>().sprite = SkillUiSprites[1];
                if (activatedSkill.is_instant)
                {
                    activatedSkill.Deactivate(this.gameObject);
                    activatedSkill.active = false;
                    activatedSkill = null;
                    activatedSkill = null;
                }
               
            }
        }
    }

}
