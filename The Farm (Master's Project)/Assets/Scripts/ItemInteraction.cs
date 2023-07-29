using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    private float interactionDistance = 2f;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject gameController;
    private GameController controller;
    [SerializeField] private TextMeshProUGUI TrapText;
    [SerializeField] private GameObject _crossHair;
    
    
    private bool textActive = false;

    private void Start()
    {
        //mainCamera = Camera.main;
        controller = gameController.GetComponent<GameController>();
        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                    }

                           
                }

                if (controller.flyPapersCollected == 6 && hit.collider.CompareTag("TrapPoints"))
                {
                    TrapText.gameObject.SetActive(true);
                    textActive = true;

                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (interactable != null)
                        {
                            interactable.Interact();
                        }
                    }
                    
                }
                else if (textActive == true)
                {
                    TrapText.gameObject.SetActive(false);
                    textActive = false;
                }
                
               
            }
        
        /*
        if(controller.flyPapersCollected == 6)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if(Physics.Raycast(ray, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();


                if (hit.collider.CompareTag("TrapPoints"))
                {
                    TrapText.gameObject.SetActive(true);
                    textActive = true;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if(interactable != null)
                        {
                            interactable.Interact();
                        }
                    }
                    
                }
                else if(textActive == true)
                {
                    
                    TrapText.gameObject.SetActive(false);
                    textActive = false;
                }

            }

            //TrapText.gameObject.SetActive(false);
        }*/
    }

    
}