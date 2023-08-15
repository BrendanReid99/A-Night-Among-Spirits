using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    public GameObject controller;
    Animator anim;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = controller.GetComponent<GameController>();
        anim = controller.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(gameController.headDownstairs == true)
        {
            anim.SetTrigger("InvestigateOutsideExit");
        }
        
    }
}
