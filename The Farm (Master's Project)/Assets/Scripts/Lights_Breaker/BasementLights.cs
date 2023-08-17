using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Maybe change this to arrays at some point and run a foreach through it.
//Separate script from other lights as 1 switch controls multiple lights.
//Changing to arrays could allow just for one script (running a foreach through an array of 1 would be virtually the same as the normal script).

public class BasementLights : MonoBehaviour, IInteractable
{
    //Variable assignment
    [SerializeField] private GameObject _light0;
    [SerializeField] private GameObject _light1;
    [SerializeField] private GameObject _light2;
    [SerializeField] private GameObject _light3;
    [SerializeField] private GameObject _light4;
    [SerializeField] private GameObject _light5;

    private Light light0;
    private Light light1;
    private Light light2;
    private Light light3;
    private Light light4;
    private Light light5;

    public bool switchOn = false;

    [SerializeField] private GameObject breaker;
    private BreakerInteract breakerInteract;

    [SerializeField] private AudioClip switchOnAudio;
    [SerializeField] private AudioClip switchOffAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        light0 = _light0.GetComponent<Light>();
        light1 = _light1.GetComponent<Light>();
        light2 = _light2.GetComponent<Light>();
        light3 = _light3.GetComponent<Light>();
        light4 = _light4.GetComponent<Light>();
        light5 = _light5.GetComponent<Light>();
        breakerInteract = breaker.GetComponent<BreakerInteract>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Turns lights on and off based on switch state and breaker state.
    public void Interact()
    {
        Debug.Log("interact");


        if (switchOn == false)
        {
            audioSource.PlayOneShot(switchOnAudio);

            if (breakerInteract.breakerOn == true)
            {
                if (light0.enabled == false)
                {
                    light0.enabled = true;
                    light1.enabled = true;
                    light2.enabled = true;
                    light3.enabled = true;
                    light4.enabled = true;
                    light5.enabled = true;
                }

                if (switchOn == false)
                {
                    switchOn = true;
                }
            }
        }
        else
        {
            audioSource.PlayOneShot(switchOffAudio);

            if (light0.enabled == true)
            {
                light0.enabled = false;
                light1.enabled = false;
                light2.enabled = false;
                light3.enabled = false;
                light4.enabled = false;
                light5.enabled = false;
            }

            if (switchOn == true)
            {
                switchOn = false;
            }
        }
    }


    // These methods are for the breaker to call when interacting with breaker.

    public void TurnLightOn()
    {
        if(breakerInteract.breakerOn == true)
        {
            if (light0.enabled == false)
            {
                light0.enabled = true;
                light1.enabled = true;
                light2.enabled = true;
                light3.enabled = true;
                light4.enabled = true;
                light5.enabled = true;
            }

        }

        
       
    }

    public void TurnLightOff()
    {
        if(light0.enabled == true)
        {
            light0.enabled = false;
            light1.enabled = false;
            light2.enabled = false;
            light3.enabled = false;
            light4.enabled = false;
            light5.enabled = false;
        }

    }

}
