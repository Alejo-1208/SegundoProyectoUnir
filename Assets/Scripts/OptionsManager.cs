using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private Toggle soundToggle;
    public static bool isSoundActive = true;

    private void Start()
    {
        GameObject objeto = GameObject.FindWithTag("SoundToggle");
        soundToggle = objeto.GetComponent<Toggle>();
        soundToggle.isOn = isSoundActive;
        AudioListener.volume = isSoundActive ? 1 : 0;
        Debug.Log(soundToggle.isOn);
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
