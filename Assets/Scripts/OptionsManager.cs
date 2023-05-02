using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private Toggle soundToggle;
    private GameObject toggleObject;
    public static bool isSoundActive = true;

    private void Start()
    {
        toggleObject = GameObject.FindWithTag("SoundToggle");
        if (toggleObject) 
        {
            soundToggle = toggleObject.GetComponent<Toggle>();
            soundToggle.isOn = isSoundActive;
            AudioListener.volume = isSoundActive ? 1 : 0;
        }
    }

    public void ChangeSoundStatus(bool state)
    {
        isSoundActive = state;
        AudioListener.volume = isSoundActive ? 1 : 0;
    }

    public void GoingBack() 
    {
        SceneManager.LoadScene("Menu");
    }
}
