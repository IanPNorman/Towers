using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;
    public GameObject menuParent;
    public float distanceInFront = 2.0f;
    public float heightOffset = 1.5f;
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
                SpawnMenu();
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
        isPaused = false;
        SceneManager.LoadScene("StartScene");
    }

    public void SpawnMenu()
    {
        Camera playerCamera = Camera.main;

        Vector3 spawnPosition = playerCamera.transform.position + playerCamera.transform.forward * distanceInFront;
        spawnPosition.y += heightOffset;
        Quaternion spawnRotation = Quaternion.LookRotation(playerCamera.transform.forward);

        menu.SetActive(true);
        menuParent.transform.position = spawnPosition;
        menuParent.transform.rotation = spawnRotation;
        isPaused = true;
    }
}
