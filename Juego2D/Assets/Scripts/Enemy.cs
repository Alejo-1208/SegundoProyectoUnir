using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    public float distance = 0.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(patrol());
    }

    IEnumerator patrol()
    {
        while (true)
        {
            rb.velocity = new Vector2(-distance,0);
            spriteRenderer.flipX = false;
            yield return new WaitForSeconds(3);

            rb.velocity = new Vector2(distance, 0);
            spriteRenderer.flipX = true;
            yield return new WaitForSeconds(3);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;

        if (normal == Vector2.down && collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Hit");
        }

        if (collision.transform.CompareTag("Player") && normal != Vector2.down)
        {
            Debug.Log("Player damage enemy, respawn activate");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }

    void dead()
    {
        Destroy(gameObject);
    }

   
}
