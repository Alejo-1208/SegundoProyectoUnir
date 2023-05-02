using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private float timeToChange = 5.0f;
    void Start()
    {
        Invoke("LoadMainMenu", timeToChange);
    }

    private void LoadMainMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
