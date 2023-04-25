using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 0f; // velocidad del objeto
    [SerializeField] public float jumpForce = 0f; // fuerza de salto
    [SerializeField] public float doubleJumpSpeed = 0f; //doble salto
                     private bool canDoubleJump = false;
    [SerializeField] public bool betterJump = false;
    [SerializeField] public float fallMultiplier = 0.5f;
    [SerializeField] public float lowJumpMultiplayer = 1f;

    [SerializeField] public SpriteRenderer spriteRenderer; // al ser publica puedo elegir la opcion que deseo en editor
    [SerializeField] public Animator animator;

    private Rigidbody2D rb;// referencia del Rb del personaje
    //private bool isGrounded = true; // verifica si el objeto está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //busca el componente 
    }

    private void Update()
    {

        /*
        if (Input.GetKeyDown("space") && CheckGround.isGrounded)
        {
                canDoubleJump = true; // permite el doble salto
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);// llama la animación para permitir saltar
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



        if (CheckGround.isGrounded == false) // cuando no este mos en el suelo, saltamos
        {

            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true) // cuando no este mos en el suelo, saltamos
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

        }// movimiento hacia la izquierda
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true; // permite hacer el flip
            animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }

        //salto ya no necesario

        /*if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }*/
        
        // revisando tierra
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

        //salto


        /*
        // movimiento horizontal que no me funciono muy bien
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rb.AddForce(movement * speed);*/

        /*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }*/

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        /*
        // verifica si el objeto ha tocado el suelo
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }*/
    }
}
