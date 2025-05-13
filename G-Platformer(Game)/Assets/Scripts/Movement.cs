using UnityEngine;

public class Movement : MonoBehaviour
{
 [SerializeField] private  Rigidbody2D rb2d;
 [SerializeField] private bool canMove, canJump, canDash, isgrounded;
 [SerializeField] KeyCode shootButton, jumpButton, dashButton;
 public float velocidadMovimiento;
  float horizontal;


    void Update()
    {
        Move();
    }
    void Move()
    {
        
         if (canMove == true)
        {
            horizontal = Input.GetAxis("Horizontal") * velocidadMovimiento;
        }
        else
        {
            horizontal = 0;
        }
            
       
    }


}
