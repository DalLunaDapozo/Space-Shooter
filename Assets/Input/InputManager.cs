using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    private static InputManager instance;
    private PlayerInput input;

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

    private void OnDestroy(){
        
        input.Keyboard.Movement.performed -= MovePressed;
    }

}