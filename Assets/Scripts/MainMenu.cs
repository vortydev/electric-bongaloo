using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioController audioController;

    public void PlayGame()
    {
        audioController.SavePlayerPrefs();

        SceneManager.LoadScene(1); // Loads scene 1 with the actual game
    }

    public void QuitGame()
    {
        audioController.SavePlayerPrefs();

        Application.Quit(); // Quits the application
        Debug.Log("Quit");
    }
}
