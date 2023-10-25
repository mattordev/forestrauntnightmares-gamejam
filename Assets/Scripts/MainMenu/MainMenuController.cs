using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <author>
/// Authored & Written by @mattordev
/// 
/// for external use, please contact the author directly
/// </author>
namespace Mattordev.menu
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
