using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class HeartMovement : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerInput playerInput;
    CharacterController characterController;

    // Variable to store player input values
    bool isMovementPressed;

    // Variable to store player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;

    // Constants
    public float speed = 3.0F;
    public bool canMove = true;


    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();

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

        characterController.Move(currentMovement * playerStats.playerStats.Speed * Time.deltaTime);
    }

        void Update()
    {
        handleMovement();
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }

    void OnDisable()
    {
        playerInput.Player.Disable();
    }

}

