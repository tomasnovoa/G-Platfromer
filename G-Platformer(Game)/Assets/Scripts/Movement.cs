using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
 
    public float velocidadMovimiento;
    public float fuerzaSalto;
     public Transform puntoSuelo;
    public float radioDeteccion = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool estaEnSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Detector();
        Jump();
        
    }
    void Move()
    {
        float direccion = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("InMove",true);
            direccion = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("InMove",true);
            direccion = 1f;
        }

        rb.linearVelocity = new Vector2(direccion * velocidadMovimiento, rb.linearVelocityY);


      if(rb.linearVelocity.magnitude == 0f)
      {
        animator.SetBool("InMove",false);
      }

    }
    void Detector()
    {
        estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioDeteccion, capaSuelo);
    }
    void Jump()
    {
      
        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityY, fuerzaSalto);
        }
    }
 
}







