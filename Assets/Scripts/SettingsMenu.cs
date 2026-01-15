using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public Slider sensitivitySlider;
    public Toggle fullscreenToggle;

    void Start()
    {
        float savedSens = PlayerPrefs.GetFloat("MouseSensitivity", 200f);
        sensitivitySlider.value = savedSens;
        fullscreenToggle.isOn = Screen.fullScreen;
    }
    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }

    // Funzione collegata al Toggle
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
}