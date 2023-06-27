using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedSleep : MonoBehaviour, IInteractable
{

    public GameObject controller;
    private GameController gameController;
    
    private float fadeDuration = 2f;
    public Image fadeBlack;

    // Start is called before the first frame update
    void Start()
    {
        fadeBlack.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        StartCoroutine(goSleep());
    }

    private IEnumerator goSleep()
    {
        

        Color currentColor = fadeBlack.color;
        Color targetColor = Color.black;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            fadeBlack.color = Color.Lerp(currentColor, targetColor, t);

            yield return null;
        }

        fadeBlack.color = targetColor;

    }
}
