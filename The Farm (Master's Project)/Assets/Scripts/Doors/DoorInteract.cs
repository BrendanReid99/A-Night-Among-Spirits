using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    //Variable assignments
    Animator anim;
    private bool doorOpen = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    //Opens or closes door when interacted with, depending on its current state. Applies to doors without locks (e.g. dining room door)
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
