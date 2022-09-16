using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class HeartMovementBossRoom : MonoBehaviour
{

    PlayerInput playerInput;
    CharacterController characterController;
    public Transform playerCamera;

    // Variable to store player input values
    bool isMovementPressed = false;

    // Variable to store player input values
    Vector2 currentMovementInput;
    Vector2 currentCameraInput;
    Vector3 currentCamera;
    Vector3 currentMovement;
    Vector3 rotatedMovement;

    // Constants
    public float speed = 3.0F;
    public float rotationSpeed = 15f;
    public bool canMove = true;
    float mDesiredRotation = 0f;

    public Animator anim;

    public bool entranceTutorial = false;
    public Image tutorialCheck1;
    public Image tutorialCheck2;

    public CinemachineFreeLook camera;

    public Animator tutorialAnim;

    public bool movAnimationFinish = false;
    public bool camAnimationFinish = false;


    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        // Set the player input callbacks
        playerInput.Player.Move.started += onMovementInput;
        playerInput.Player.Move.canceled += onMovementInput;
        playerInput.Player.Move.performed += onMovementInput;
    }

    public void freeze()
    {
        canMove = false;
    }


    public void release()
    {
        canMove = true;
    }



    void onMovementInput(InputAction.CallbackContext context)
    {
       
        currentMovementInput = context.ReadValue<Vector2>();
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        
    }

    public void Look2(InputAction.CallbackContext context)
    {
        if (movAnimationFinish)
        {
            currentCameraInput = context.ReadValue<Vector2>(); 
        }
       

    }

    void handleMovement()
    {
        currentMovement = new Vector3(currentMovementInput.x, 0, currentMovementInput.y);
        rotatedMovement = Quaternion.Euler(0, playerCamera.transform.rotation.eulerAngles.y, 0) * currentMovement;
       

        characterController.Move(rotatedMovement * speed * Time.deltaTime);

        if (rotatedMovement.magnitude > 0)
        {
            mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
        }

        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void HandleAnimation()
    {
        if(isMovementPressed)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Update()
    {
        if(canMove)
        {
            handleMovement();
            HandleAnimation();
        }

        if (currentCameraInput.magnitude > 0 && entranceTutorial && movAnimationFinish)
        {
            tutorialCheck1.gameObject.SetActive(true);
            StartCoroutine(TutorialAnim());
        }

        if (currentMovement.magnitude > 0 && entranceTutorial && camAnimationFinish)
        {
            tutorialCheck2.gameObject.SetActive(true);
            StartCoroutine(TutorialAnimFinish());
        }


    }

    IEnumerator TutorialAnim()
    {

        tutorialAnim.SetTrigger("camera");

        yield return new WaitForSeconds(1f);

    }

    IEnumerator TutorialAnimFinish()
    {

        tutorialAnim.SetTrigger("end");

        yield return new WaitForSeconds(1f);

    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

}

