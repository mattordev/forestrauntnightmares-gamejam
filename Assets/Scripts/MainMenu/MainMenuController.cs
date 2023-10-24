using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string gameScene;


    public void PlayGame()
    {
        Debug.Log($"Loading {gameScene}");
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
