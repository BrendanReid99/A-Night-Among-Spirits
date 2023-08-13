using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BreakerInteract : MonoBehaviour, IInteractable
{

    Animator anim;
    public bool breakerOn = true;
    public bool stageTwo = false;
    [SerializeField] private GameObject[] lightsArray;
    [SerializeField] private GameObject PPV;
    [SerializeField] private GameObject bedroom2Door;
    [SerializeField] private GameObject controllerHolder;
    private Bedroom2Door doorScript;

    private GameController controller;
    private Animator controllerAnim;


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
        doorScript = bedroom2Door.GetComponent<Bedroom2Door>();
        controller = controllerHolder.GetComponent<GameController>();
        controllerAnim = controllerHolder.GetComponent<Animator>();
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
            if(stageTwo == true)
            {
                postProcessVolume.enabled = true;
                mainCamera.cullingMask = spiritWorldMask;
                doorScript.SpiritWorld(true);
                controllerAnim.SetTrigger("FindBreakerExit");
                controllerAnim.SetTrigger("OtherSide");
            }
           
            TurnLightsOn();
        }
        else
        {
            //Debug.Log("turn breaker off");
            anim.Play("BreakerOff");
            breakerOn = false;
            if(stageTwo == true)
            {
                postProcessVolume.enabled = false;
                mainCamera.cullingMask = realWorldMask;
                doorScript.SpiritWorld(false);
                controllerAnim.SetTrigger("RealSide");
            }
            
            TurnLightsOff();


        }
    }

    public void TurnLightsOff()
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
        if(stageTwo == true)
        {
            RenderSettings.ambientIntensity = 2.5f;
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
        RenderSettings.ambientIntensity = 0.0f;
    }
}
