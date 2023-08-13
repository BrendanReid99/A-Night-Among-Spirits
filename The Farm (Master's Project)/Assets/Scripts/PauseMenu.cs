using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void resumeGame() { 
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("resume game clicked");
    }

    public void exitGame() { 
        Application.Quit();
    }
}
