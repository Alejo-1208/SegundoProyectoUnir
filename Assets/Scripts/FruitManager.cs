using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    [SerializeField] public Text levelCleared;//

    public Text totalFruits;

    public Text fruitsCollected;

    public int totalFruitsInLevel; //Llama el texto para contar las frutas totales de nivel

    private void Start()
    {
		totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitsCollected();
        //totalFruits.text = totalFruitsInLevel.ToString(); Esta desactivado porque muestra las frutas totales
        fruitsCollected.text = transform.childCount.ToString(); // frutas que faltan por coger 
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Recogiste todas las frutas");
            // levelCleared.gameObject.SetActive(true);// no sirve de momento
            Invoke("ChangeScene",1);//
            
        }
    }

     void ChangeScene()
     {
             // carga una escena y luego le suma uno para seguir a la siguiente
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
     }
}
