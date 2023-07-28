using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    private float interactionDistance = 2f;
    private Camera mainCamera;

    [SerializeField] private GameObject _crossHairObject;
    private Image _crossHair;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _crossHair = _crossHairObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                _crossHair.color = Color.white;

            }
            else
            {
                _crossHair.color = Color.grey;
            }
        }

        else
        {
            _crossHair.color = Color.grey;
        }
    }

}
