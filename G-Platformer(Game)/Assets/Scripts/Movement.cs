using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove;
    public Animator animator;

    public float velocidadMovimiento;
    public float fuerzaSalto;
    private float currentJumpForce;
    public Transform puntoSuelo;
    public float radioDeteccion = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool estaEnSuelo;

    private bool preparandoSalto;

    void Start()
    {
        NoMoverse();
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
        if (Input.GetKey(KeyCode.A) && canMove)
        {
            animator.SetBool("InMove", true);
            direccion = -1f;
        }
        else if (Input.GetKey(KeyCode.D) && canMove)
        {
            animator.SetBool("InMove", true);
            direccion = 1f;
        }
        else if (!canMove)
        {
            direccion = 0f;
        }

        rb.linearVelocity = new Vector2(direccion * velocidadMovimiento, rb.linearVelocityY);


        if (rb.linearVelocity.magnitude == 0f)
        {
            animator.SetBool("InMove", false);
        }

    }
    void Detector()
    {
        estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioDeteccion, capaSuelo);
    }
    public void Moverse()
    {
        canMove = true;
    }
    public void NoMoverse()
    {
        canMove = false;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && estaEnSuelo && canMove)
        {

            animator.SetBool("HoldJump", true);



            preparandoSalto = true;
        }

        if (Input.GetButtonUp("Jump") && estaEnSuelo && preparandoSalto && canMove)
        {
            animator.SetTrigger("InJump");
            animator.SetBool("HoldJump", false);
            float value = fuerzaSalto * currentJumpForce;
            rb.linearVelocity = new Vector2(rb.linearVelocityY, value);
            preparandoSalto = false;
        }
    }

    public void holdJump(float valor)
    {
        currentJumpForce = valor;
    }
}







