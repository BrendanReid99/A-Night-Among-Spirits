using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLights : MonoBehaviour, IInteractable
{
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        Debug.Log("interact");


        if (switchOn == false)
        {
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
