using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelName = "UITestScene"; // name for scene that should be loaded
    public void PlayGame()
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
