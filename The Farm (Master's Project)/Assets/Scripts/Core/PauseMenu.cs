using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

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
}
