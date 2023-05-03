using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    void FixedUpdate()
    {
        if (Input.GetKey("p") && pauseMenu != null)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

    }

    public void returnGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void exitGame()
    {
        SceneManager.LoadScene("Menu");
        //Application.Quit();
    }
}
