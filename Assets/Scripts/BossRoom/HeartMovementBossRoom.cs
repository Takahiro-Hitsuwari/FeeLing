using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    Vector3 currentMovement;
    Vector3 rotatedMovement;

    // Constants
    public float speed = 3.0F;
    public float rotationSpeed = 15f;
    public bool canMove = true;
    float mDesiredRotation = 0f;

    public Animator anim;




    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        // Set the player input callbacks
        playerInput.Player.Move.started += onMovementInput;
        playerInput.Player.Move.canceled += onMovementInput;
        playerInput.Player.Move.performed += onMovementInput;
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
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

