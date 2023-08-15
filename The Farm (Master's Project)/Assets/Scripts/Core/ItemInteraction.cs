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
        
            //Fires raycast from the middle of the screen (same placement as crosshair).
            //Raycast returns objects it hits within interaction distance.
            //If said object calls the interactable interface, then E can be pressed and it will call the Interact() function on that object.

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
                

                //Checks if the player has collected enough flypaper to make a trap, and if the raycasted obj is a trap point.
                //If so, displays text to tell the player they can place the trap with F.
                //Text disappears when no longer raycasting to that obj.
                if (controller.flyPapersCollected == 3 && hit.collider.CompareTag("TrapPoints"))
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
        
    }

    
}