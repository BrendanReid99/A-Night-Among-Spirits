using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject gameController;
    private GameController controller;
    [SerializeField] private GameObject trap;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(controller.flyPapersCollected == 6)
        {
            trap.SetActive(true);
        }
    }
}
