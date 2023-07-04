using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject _switch;
    private Light light;

    public bool switchOn = false;

    // Start is called before the first frame update
    void Start()
    {
        light = _switch.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (switchOn == false)
        {
            light.enabled = true;
            switchOn = true;
        }
        else
        {
            light.enabled = false;
            switchOn = false;
        }
    }
}
