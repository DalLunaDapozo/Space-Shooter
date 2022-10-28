using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    private static InputManager instance;
    private PlayerInput input;

    public EventHandler on_spawn_pressed;
   
    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Found more than one Input Manager in the scene.");
        instance = this;

        input = new PlayerInput();

        SubscribeToInputs();
    }

    public void EnableInput(){
        input.Enable();
        input.Keyboard.Spawn.performed += SpawnButtonPressed;
    }
    public void DisableInput(){
        input.Disable();
    }

    public static InputManager GetInstance(){
        
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context){
        
        moveDirection = input.Keyboard.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMoveDirection(){
        return moveDirection;
    }

    private void SubscribeToInputs(){
        
        input.Keyboard.Movement.performed += MovePressed;
    }

    public void SpawnButtonPressed(InputAction.CallbackContext context)
    {
        on_spawn_pressed?.Invoke(this, EventArgs.Empty);
    }

}