using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEMPORARY SOLUTION - Will make it more immersive if time allows

public class BoundaryTrigger : MonoBehaviour
{
    //Variable assignments
    [SerializeField] private GameObject respawnPoint;
    private GameObject player;
    private Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        targetpos = respawnPoint.transform.position;
    }

    //If player exits boundary box, they're teleported back to entrance of the house.
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Exit");

        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Exited Area - teleporting to: " + respawnPoint.transform.position);

            player.transform.position = targetpos;
            Debug.Log("Player position is: " + player.transform.position + " but should be " + respawnPoint.transform.position);
        }
    }
}
