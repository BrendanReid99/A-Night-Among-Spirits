using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedSleep : MonoBehaviour, IInteractable
{

    public GameObject controller;
    private GameController gameController;
    Animator anim;

    private float fadeDuration = 2f;
    public Image fadeBlack;

    private bool hasSlept = false;

    // Start is called before the first frame update
    void Start()
    {
        fadeBlack.color = Color.clear;
        gameController = controller.GetComponent<GameController>();
        anim = controller.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (hasSlept == false)
        {
            StartCoroutine(goSleep());
            hasSlept = true;
        }

    }

    private IEnumerator goSleep()
    {

        anim.SetTrigger("ExploreExit");

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

        yield return new WaitForSeconds(2);

        timer = 0f;
        
        anim.SetTrigger("GoToBedExit");

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            fadeBlack.color = Color.Lerp(targetColor, currentColor, t);

            yield return null;
        }

        fadeBlack.color = currentColor;

        

    }
}
