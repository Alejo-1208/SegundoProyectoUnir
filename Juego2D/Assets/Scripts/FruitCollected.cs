using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource audioFruit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //FindObjectOfType<FruitManager>().AllFruitsCollected();//trae el metodo para saber cuantas frutas quedan

            Destroy(gameObject, 0.5f);

            audioFruit.Play();


        }
    }
}
