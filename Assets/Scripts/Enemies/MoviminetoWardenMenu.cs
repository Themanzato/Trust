using System.Collections;
using UnityEngine;

public class MoviminetoWardenMenu : MonoBehaviour
{
    public RectTransform warden;
    public float speed;
    public float pauseTime;

    private bool isMoving = true;
    private bool canMove = true;
    private float nextActionTime = 0.0f;

    // Variables de estado para la animación
    private bool parado = false;
    private bool moviendose = true;
    private bool ataca = false;
    private bool ataca2 = false;
    private bool ataca1y2 = false;
    private bool idleattack = true;

    // Posición objetivo en X
    private float targetXPosition = -158.15f;

    private Animator animator;

    void Start()
    {
        nextActionTime = Time.time + pauseTime;
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Time.time >= nextActionTime)
        {
            isMoving = !isMoving;
            nextActionTime = Time.time + pauseTime;
        }

        if (canMove && warden != null && isMoving)
        {
            idleattack = false;
            Move();
        }
    }

    void Move()
    {
        if (warden.anchoredPosition.x < targetXPosition)
        {
            warden.anchoredPosition += Vector2.right * speed * Time.deltaTime;

            if (warden.anchoredPosition.x >= targetXPosition)
            {
                warden.anchoredPosition = new Vector2(targetXPosition, warden.anchoredPosition.y);
                StopMovement();
            }
        }
    }

    public void StopMovement()
    {
        isMoving = false;
        canMove = false;
        
        idleattack = true;
        UpdateAnimator();
    }

    

    

    void UpdateAnimator()
    {
        animator.SetBool("parado", parado);
        animator.SetBool("moviendose", moviendose);
        animator.SetBool("ataca", ataca);
        animator.SetBool("ataca2", ataca2);
        animator.SetBool("ataca1y2", ataca1y2);
        animator.SetBool("idleattack", idleattack);
    }
}
