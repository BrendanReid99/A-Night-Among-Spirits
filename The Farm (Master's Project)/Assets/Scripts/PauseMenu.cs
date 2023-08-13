using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void gamePaused() {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame() { 
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitGame() { 
        Application.Quit();
    }
}
