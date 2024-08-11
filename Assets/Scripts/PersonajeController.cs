using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactertControler : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private Animator animator;
    private bool canMove = true;

    //input sistem
    private EntradasMovimiento entradasMovimiento;

    private void Awake()
    {
        entradasMovimiento = new EntradasMovimiento();
    }

    private void OnEnable()
    {
        entradasMovimiento.Enable();
    }

    private void OnDisable()
    {
        entradasMovimiento.Disable();
        Sign.OnShowText -= HandleShowText;

    }

    //fin input sistem

    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        Sign.OnShowText += HandleShowText;
    }

    void HandleShowText(bool isTextShown)
    {
        canMove = !isTextShown;

        if (isTextShown)
        {
            StartCoroutine(EnableMovementAfterDelay(5f));
        }
    }

    private IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove)
        {
            ProcesarMovimiento();
            ProcesarSalto(entradasMovimiento.Movimiento.Salto.ReadValue<float>());
        }
        
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.1f, capaSuelo);
        return raycastHit.collider != null;
    }


    void ProcesarSalto(float valorSalto)
    {
        if (valorSalto > 0 && EstaEnSuelo())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, fuerzaSalto);

        }
    
        
        if (EstaEnSuelo() == false)
        {
            animator.SetBool("IsJumping", true);
        }

        else

        {

            animator.SetBool("IsJumping", false);
        }

    }

    void ProcesarMovimiento()
    {
        // Logica de Movimiento
        float inputMovimiento = entradasMovimiento.Movimiento.Horizontal.ReadValue<float>();
        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);

        GestionarOrientacion(inputMovimiento);

        // Logica de Animacion
        if (inputMovimiento != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        
    }

    void GestionarOrientacion(float inputmovimiento)
    {
        // Si se cumple condición
        if ((mirandoDerecha == true && inputmovimiento < 0) || (mirandoDerecha == false && inputmovimiento > 0))
        {
            // Ejecutar código de volteado 
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void DerechaPresionada()
    {
        if (rigidBody.velocity.x > 0)
        {
            Debug.Log("Derecha presionada");
        }
    }
}
