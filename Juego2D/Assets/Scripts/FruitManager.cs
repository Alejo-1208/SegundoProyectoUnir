using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    [SerializeField] public Text levelCleared;//

    private void Update()
    {
        AllFruitsCollected();
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
