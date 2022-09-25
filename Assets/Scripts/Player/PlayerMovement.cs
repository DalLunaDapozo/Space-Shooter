using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
  
    private Vector2 input_axis = Vector2.zero;

    [SerializeField] private float movement_speed = 10f;

    private void OnEnable(){
       
        InputManager.GetInstance().EnableInput();
    }
    private void Awake(){
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        
        PassAxisValueToVelocity();
    }
    private void PassAxisValueToVelocity(){
        
        rb.velocity = ReadInputAxis() * movement_speed * Time.deltaTime;
    }
    private Vector2 ReadInputAxis()
    {

        input_axis = InputManager.GetInstance().GetMoveDirection();
        return input_axis;
    }
}
