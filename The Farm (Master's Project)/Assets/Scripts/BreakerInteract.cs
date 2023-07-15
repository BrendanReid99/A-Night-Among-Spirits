using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BreakerInteract : MonoBehaviour, IInteractable
{

    Animator anim;
    public bool breakerOn = true;
    [SerializeField] private GameObject[] lightsArray;
    [SerializeField] private GameObject PPV;
    private PostProcessVolume postProcessVolume;

    public LayerMask realWorldMask;
    public LayerMask spiritWorldMask;

    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        postProcessVolume = PPV.GetComponent<PostProcessVolume>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(breakerOn == false)
        {
            //Debug.Log("turn breaker on");
            anim.Play("BreakerOn");
            breakerOn = true;
            postProcessVolume.enabled = false;
            mainCamera.cullingMask = realWorldMask;
            TurnLightsOn();
        }
        else
        {
            //Debug.Log("turn breaker off");
            anim.Play("BreakerOff");
            breakerOn = false;
            postProcessVolume.enabled = true;
            mainCamera.cullingMask = spiritWorldMask;
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
        RenderSettings.ambientIntensity = 2.5f;
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
        RenderSettings.ambientIntensity = 0.0f;
    }
}
