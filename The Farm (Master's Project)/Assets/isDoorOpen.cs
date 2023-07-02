using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDoorOpen : MonoBehaviour, IInteractable
{
    private GameController gameController;
    public GameObject controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        gameController = controller.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact() {
        if (gameController.checkDoor == true) {
            anim.SetTrigger("InvestigateBangingExit");
        }
    }
}
