using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player damage enemy, respawn activate");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
