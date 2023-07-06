using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerInteract : MonoBehaviour, IInteractable
{

    Animator anim;
    public bool breakerOn = true;
    [SerializeField] GameObject[] lightsArray;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(breakerOn == false)
        {
            Debug.Log("turn breaker on");
            anim.Play("BreakerOn");
            breakerOn = true;
            TurnLightsOn();
        }
        else
        {
            Debug.Log("turn breaker off");
            anim.Play("BreakerOff");
            breakerOn = false;

            TurnLightsOff();


        }
    }

    private void TurnLightsOff()
    {
        foreach (GameObject obj in lightsArray)
        {
            if(obj.tag == "BasementLight")
            {
                obj.GetComponent<BasementLights>().TurnLightOff();
            }
            else
            {
                obj.GetComponent<Lightswitch>().TurnLightOff();
            }
        }
    }

    private void TurnLightsOn()
    {
        foreach (GameObject obj in lightsArray)
        {
            if(obj.tag == "BasementLight")
            {

                if(obj.GetComponent<BasementLights>().switchOn == true)
                {
                    obj.GetComponent<BasementLights>().TurnLightOn();
                }
            }
            else
            {
                if(obj.GetComponent<Lightswitch>().switchOn == true)
                {
                    Debug.Log(obj.GetComponent<Lightswitch>().switchOn);
                    obj.GetComponent<Lightswitch>().TurnLightOn();
                }
            }
        }
    }
}
