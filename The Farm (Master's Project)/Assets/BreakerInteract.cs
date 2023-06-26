using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerInteract : MonoBehaviour, IInteractable
{

    Animator anim;
    private bool breakerOn = false;

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
            anim.Play("breakerOn");
            breakerOn = true;
        }
        else
        {
            Debug.Log("turn breaker off");
            anim.Play("breakerOff");
            breakerOn = false;
        }
    }
}