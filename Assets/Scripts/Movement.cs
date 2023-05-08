using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 0f; // velocidad del objeto
    public float jumpForce = 0f; // fuerza de salto
    public float doubleJumpSpeed = 0f; //doble salto
    private bool canDoubleJump = false;
    public bool  betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplayer = 1f;

    private float horizontal;
    public bool isWallSliding;
    public float wallSlidingSpeed = 2f;

    //lo dejo [SerializeField] para pasarle los datos por el editor de unity 
    [SerializeField] public SpriteRenderer spriteRenderer; 
    [SerializeField] public Animator animator;
    [SerializeField] public Transform wallCheck;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask wallLayer;


    private Rigidbody2D rb;// referencia del Rb del personaje
    //private bool isGrounded = true; // verifica si el objeto est� en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //busca el componente 
    }

    private void Update()
    {
        wallSlide();
        /* es una forma de hacerlo pero no recomendado, sin embargo la dejo por si es
           util en algun momento
        if (Input.GetKeyDown("space") && CheckGround.isGrounded)
        {
                canDoubleJump = true; // permite el doble salto
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);// llama la animaci�n para permitir saltar
                        rb.velocity = Vector2.zero; 
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false; // no permite el doble salto
                    }
                } */

        if (Input.GetButtonDown("Jump") && CheckGround.isGrounded)
        {

            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
            //animator.SetTrigger("jump");
            canDoubleJump = false;
        }
        

        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
        }



        if (CheckGround.isGrounded == false) // false para poner los estados de forma que salte
        {

            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true) // true para que no haga doble salto
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            if (rb.velocity.y > 0)
            {
            animator.SetBool("Falling", false);
            }
        }

    }

    void FixedUpdate()
    {

        // movimiento horizontal

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = false; //no permite hacer el flip
            animator.SetBool("Run", true);
            wallSlide();


        }// movimiento hacia la izquierda
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true; // permite hacer el flip
            animator.SetBool("Run", true);
            wallSlide();

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }
        
        // revisando contacto con la tierra
        if (CheckGround.isGrounded == false) // cuando no este mos en el suelo, saltamos
        {
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);
        }
        if (CheckGround.isGrounded == true) // cuando no este mos en el suelo, saltamos
        {
            animator.SetBool("Jump", false);
        }

        
        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb.velocity.y > 0 && Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }

        if (isWallSliding)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
        }

        
    }

    public bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if (isWalled() && !CheckGround.isGrounded && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    
}
