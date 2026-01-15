using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public GameObject mainMenuPanel;  
    public GameObject optionsMenuPanel; 
    void Start()
    {
        // Forza lo stato iniziale corretto
        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void Debug1()
    {
        SceneManager.LoadScene("Debug1");
    }
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);   
        optionsMenuPanel.SetActive(true); 
    }

    public void CloseOptions()
    {
        optionsMenuPanel.SetActive(false); 
        mainMenuPanel.SetActive(true);     
    }
}