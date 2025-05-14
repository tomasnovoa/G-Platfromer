using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento;
    public float fuerzaSalto;

    [Header("Detección de suelo")]
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
            direccion = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direccion = 1f;
        }

        rb.linearVelocity = new Vector2(direccion * velocidadMovimiento, rb.linearVelocityY);
    }
    void Detector()
    {
        estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioDeteccion, capaSuelo);
    }
    void Jump()
    {
        // Salto
        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityY, fuerzaSalto);
        }
    }
 
}







