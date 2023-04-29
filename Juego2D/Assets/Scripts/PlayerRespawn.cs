using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionX;
    private float checkPointPositionY;
    public Animator animator;
    public GameObject[] Corazones;
    public int life;

    private void Start()
    {   
        life = Corazones.Length;

        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    } 
    private void CheckLife()
    {
        if (life < 1)
        {        
			Destroy(Corazones[0].gameObject);
			animator.Play("Hit");//llama al estado Hit en la rama de animación
			animator.Play("Idle");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);//recargue la escena
            
		}
        else if (life < 2)
        {
			animator.Play("Hit");//llama al estado Hit en la rama de animación
			Destroy(Corazones[1].gameObject);
			animator.Play("Idle");
		}
        else if (life < 3)
        {
			animator.Play("Hit");//llama al estado Hit en la rama de animación
			Destroy(Corazones[2].gameObject);
			animator.Play("Idle");
		}
    }
}
