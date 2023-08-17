using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour, IInteractable
{
    //Variable assignment
    [SerializeField] private GameObject _switch;
    [SerializeField] private GameObject breaker;
    [SerializeField] private AudioClip switchOnAudio;
    [SerializeField] private AudioClip switchOffAudio;
    private BreakerInteract breakerInteract;
    private Light light;

    public bool switchOn = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        light = _switch.GetComponent<Light>();
        breakerInteract = breaker.GetComponent<BreakerInteract>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Turns light on or off, depending on switch state and breaker state.
    public void Interact()
    {
        if (switchOn == false)
        {
            if(breakerInteract.breakerOn == true)
            {
                light.enabled = true;
                switchOn = true;
                audioSource.PlayOneShot(switchOnAudio);
            }
            
        }
        else
        {
            if(breakerInteract.breakerOn == true)
            {
                light.enabled = false;
                switchOn = false;
                audioSource.PlayOneShot(switchOffAudio);
            }
        }
    }

    // These methods are for the breaker to call when interacting with breaker.

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
