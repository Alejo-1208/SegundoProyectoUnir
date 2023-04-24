using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 0f; // velocidad del objeto
    [SerializeField] public float jumpForce = 0f; // fuerza de salto
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

    void Update()
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

        //salto

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
            //Debug.Log(CheckGround.isGrounded);
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
