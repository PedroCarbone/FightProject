using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float distancia;
    public Rigidbody2D rb2D;
    // public Transform jugador;
    public Vector3 puntoInicial;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool mirandoDerecha = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        // distancia = Vector2.Distance(transform.position, Soldado.position);
        animator.SetFloat("Distancia", distancia);
    }

    public void Girar(Vector3 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            animator.SetTrigger("Muerte");
            //Muerte();
        }
    }

    //private void Muerte()
    //{
    //    Destroy(gameObject);
    //}
}