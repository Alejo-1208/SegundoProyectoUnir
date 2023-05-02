using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadOptions() 
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadCredits() 
    {
        SceneManager.LoadScene("Credits");
    }
}
