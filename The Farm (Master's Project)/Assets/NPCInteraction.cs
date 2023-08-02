using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{

    public float bobbingSpeed = 1f; // Adjust the speed of bobbing here
    public float bobbingHeight = 0.5f; // Adjust the height of bobbing here

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new Y position using Mathf.Sin to create a bobbing effect
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Set the new position of the GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    public void Interact()
    {

    }


}
