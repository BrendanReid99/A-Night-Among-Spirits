using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlypaperCollect : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject gameController;
    private GameController controller;
    [SerializeField] private GameObject paper;

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
        controller.CollectFlypaper();
        Destroy(paper);
    }

}
