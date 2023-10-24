using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace mattordev.menu
{
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
}
