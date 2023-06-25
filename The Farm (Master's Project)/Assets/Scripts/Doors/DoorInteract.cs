using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{

    Animator anim;
    private bool doorOpen = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

   public void Interact()
    {
        if(doorOpen == false)
        {
            anim.Play("Door1 open");
            doorOpen = true;
        }
        else
        {
            anim.Play("Door1 close");
            doorOpen = false;
        }
        Debug.Log("Working");
    }
}
