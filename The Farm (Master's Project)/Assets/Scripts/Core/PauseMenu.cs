using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject controlsCanvas;

    public void resumeGame() { 
        
        Time.timeScale = 1;
        Debug.Log("resume game clicked");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
    }

    public void exitGame() { 
        Application.Quit();
    }

    public void controlsMenu()
    {
        Time.timeScale = 0;
        Debug.Log("controls menu clicked");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void backButton()
    {
        Time.timeScale = 0;
        Debug.Log("back button clicked");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controlsCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        
    }
}
