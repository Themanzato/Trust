using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideController : MonoBehaviour
{
    //Template written by: '84.74' See: <Link>.

    //Public: (Variables that are likley to be adjusted).
    [Header("Settings:"), Range(1, 20), Tooltip("This variable affects the final velocity of your players movement. ")]
    public float WalkSpeed;
    [Range(1, 20), Tooltip("This variable affects the amount of force your player exerts when jumping. ")]
    public float JumpForce;
    [Range(1,5), Tooltip("The length of the raycast determines at what point your player is considered 'grounded'")]
    public float RayCastLength;
    public bool grounded = false;
    public KeyCode JumpKey;

    //Private: (Doesn't need to be seen in the inspector window / adjusted).
    private GameObject PlayerSprite;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private  Vector3 LeftTurn = new Vector3(0, 180, 0), RightTurn = Vector3.zero, JumpHeight; //It's less costly to define these variables here.
    private Vector2 newPosition;//Use this to store your player's direction and velocity.

    void Start() //Define several variables at the start to make the runtime more effcient.
    {
        PlayerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        rigidBody = GetComponent<Rigidbody2D>();
        animator = PlayerSprite.GetComponent<Animator>();
    }

    void Update()
    {
        JumpHeight = Vector3.zero;
        grounded = false;

        //This raycast determines whether your player is grounded.
        RaycastHit2D hit2D = Physics2D.Raycast(PlayerSprite.transform.position, -Vector2.up, RayCastLength);
        //Movement:
        if(hit2D.collider != null)
        {
           grounded = true;
        }

        //Flip GameObject corresponding to Input.Axis direction.
        if (Input.GetAxis("Horizontal") < 0) //Flip sprite to face left.
        {
            PlayerSprite.transform.eulerAngles = LeftTurn;
        }
        else if(Input.GetAxis("Horizontal") > 0)//Flip sprite to face right.
        {
            PlayerSprite.transform.eulerAngles = RightTurn;
        }

        //Jump:
        if(Input.GetKeyDown(JumpKey) && grounded == true) //If you don't want to allow an 'infinite-jump' you want to make sure the player is grounded first; before jumping.
        {
            JumpHeight = transform.up * JumpForce;
            animator.Play("Jump");
        }

        //Transformation:
        newPosition = (Vector3.right * Input.GetAxis("Horizontal") * WalkSpeed) * Time.deltaTime + JumpHeight; //The overall, movement calculation. (Don't make this local).
        rigidBody.AddForce(newPosition, ForceMode2D.Impulse); 

        //Animation:
        animator.SetFloat("HorizontalSpeed", Input.GetAxis("Horizontal")); //Allows the animator to play your 'running animation' if the input axis is not equal to zero.

        //Debug: (Remove on game build / for playtesting purposes only).
        Debug.DrawRay(PlayerSprite.transform.position, transform.TransformDirection(-Vector3.up) * RayCastLength, Color.red);
    }
}
