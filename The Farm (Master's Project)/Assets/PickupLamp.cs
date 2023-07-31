using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLamp : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject playerLamp;
    [SerializeField] private GameObject roomLamp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        playerLamp.gameObject.SetActive(true);
        
        
        roomLamp.SetActive(false);
    }
}
