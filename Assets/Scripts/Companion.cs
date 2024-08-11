using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Companion : MonoBehaviour
{
    public GameObject Personaje;
    public float speed;
    public float fuerzaSalto;
    public LayerMask capaSuelo;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private bool puedeSaltar = true;
    private EntradasMovimiento entradasMovimiento;




    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            rigidBody = gameObject.AddComponent<Rigidbody2D>();
            rigidBody.gravityScale = 0;
        }

        entradasMovimiento = new EntradasMovimiento();
        entradasMovimiento.Enable();

    }

    void Update()
    {
        if (!enabled)
        {
         return;
        }

        FlipSprite();
        FollowPersonaje();
        CheckIfGrounded();
        ProcesarSalto(entradasMovimiento.Movimiento.Salto.ReadValue<float>());

        

    }


    void ProcesarSalto(float valorSalto)
    {
        if (valorSalto > 0 && puedeSaltar == true && CheckIfGrounded())
    {

        Invoke("RealizarSalto", 0.3f);
    }

        if (CheckIfGrounded() == false)
        {
            animator.SetBool("IsJumpingCat", true);
        }
        else
        {
            animator.SetBool("IsJumpingCat", false);
        }
    }

    void RealizarSalto()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, fuerzaSalto);
        puedeSaltar = false;

        Invoke("PermitirSalto", 1f);
    }

    void PermitirSalto()
    {

        puedeSaltar = true;

    }

    void FlipSprite()
    {
        if (Personaje.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (Personaje.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FollowPersonaje()
    {
        float distanceToPersonaje = Personaje.transform.position.x - transform.position.x;
        bool isGrounded = CheckIfGrounded();

        Debug.Log(distanceToPersonaje);

        if (isGrounded)
        {
            if (Mathf.Abs(distanceToPersonaje) < 1.5)
            {
                rigidBody.velocity = Vector2.zero;
                SetIsRunning(false);
                return;
            }

            SetIsRunning(true);
            rigidBody.velocity = new Vector2(distanceToPersonaje * speed, rigidBody.velocity.y);
        }
        else
        {
            SetIsRunning(true);
            rigidBody.velocity = new Vector2(distanceToPersonaje * speed, rigidBody.velocity.y);
        }
    }

    bool CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, capaSuelo);
        return hit.collider != null;

        

    }

    void SetIsRunning(bool isRunning)
    {
        if (animator != null)
        {
            animator.SetBool("IsRunningCat", isRunning);

        }
    }
}
