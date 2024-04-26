using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                menu.SetActive(false);
                isPaused = false;
            }
            else
            {
                menu.SetActive(true);
                isPaused = true;
            }
        }
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        isPaused = false;
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
