using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS FOR FRONT DOOR ONLY

public class isDoorOpen : MonoBehaviour, IInteractable
{
    //Variable assignments
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

    //Opens or closes door depending on its current state, also triggers one of the objective states at a certain point in the game.
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
