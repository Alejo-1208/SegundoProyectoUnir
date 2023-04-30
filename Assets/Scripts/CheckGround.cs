using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
   public static bool isGrounded = true;

    //metodo prefab para saber cuando entra en contacto con el piso
    private void OnTriggerEnter2D(Collider2D collision)
    {
         isGrounded = true;
    }

    //no esta tocando el suelo
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    
}
