using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedSleep : MonoBehaviour, IInteractable
{

    public GameObject controller;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _breaker;
    private BreakerInteract breaker;
    private GameController gameController;
    Animator anim;
    Animator doorAnim;
    Animator breakerAnim;

    private float fadeDuration = 2f;
    public Image fadeBlack;

    private bool hasSlept = false;

    public GameObject terrainStart;
    public GameObject terrainClosed;


    // Start is called before the first frame update
    void Start()
    {
        fadeBlack.color = Color.clear;
        gameController = controller.GetComponent<GameController>();
        anim = controller.GetComponent<Animator>();
        doorAnim = _door.GetComponent<Animator>();
        breaker = _breaker.GetComponent<BreakerInteract>();
        breakerAnim = _breaker.GetComponent<Animator>();
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
            doorAnim.Play("Door1 close");
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

        terrainStart.SetActive(false);
        terrainClosed.SetActive(true);
        _car.SetActive(false);
        //breaker.TurnLightsOff();
        breaker.Interact();
        breaker.stageTwo = true;
        //breaker.breakerOn = false;
        breakerAnim.Play("BreakerOff");

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
