using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDoorOpen : MonoBehaviour, IInteractable
{
    private GameController gameController;
    public GameObject controller;
    private bool doorOpen = false;
    Animator anim;
    Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = controller.GetComponent<Animator>();
        gameController = controller.GetComponent<GameController>();
        doorAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {

        if (gameController.checkDoor == true)
        {
            anim.SetTrigger("InvestigateBangingExit");
            
        }


        if (doorOpen == false)
        {
            doorAnim.Play("Door1 open");
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("Door1 close");
            doorOpen = false;
        }
        
        
        
    }
}
