using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject _switch;
    [SerializeField] private GameObject breaker;
    private BreakerInteract breakerInteract;
    private Light light;

    public bool switchOn = false;

    // Start is called before the first frame update
    void Start()
    {
        light = _switch.GetComponent<Light>();
        breakerInteract = breaker.GetComponent<BreakerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (switchOn == false)
        {
            if(breakerInteract.breakerOn == true)
            {
                light.enabled = true;
                switchOn = true;
            }
            
        }
        else
        {
            if(breakerInteract.breakerOn == true)
            {
                light.enabled = false;
                switchOn = false;
            }
        }
    }

    public void TurnLightOn()
    {
        if(breakerInteract.breakerOn == true)
        {
            if (light.enabled == false)
            {
                light.enabled = true;
            }
           
        }
        
    }

    public void TurnLightOff()
    {

        if(light.enabled == true)
        {
            light.enabled = false;
        }
        
    }
}
