using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyTeleport : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform[] pointsArray;
    [SerializeField] private GameObject teddy;
    private float teleportInterval = 20f;
    private int currentIndex = 0;
    private bool trapped = false;

    [SerializeField] private GameObject gameController;
    private GameController controller;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TeleportTeddy());
        controller = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private IEnumerator TeleportTeddy()
    {
        while (true)
        {
            teddy.transform.position = pointsArray[currentIndex].position;
            teddy.transform.rotation = pointsArray[currentIndex].rotation;

            yield return new WaitForSeconds(teleportInterval);

            currentIndex = (currentIndex + 1) % pointsArray.Length;
        }
    }
    */

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && trapped == false)
        {
            teddy.transform.position = pointsArray[currentIndex].position;
            teddy.transform.rotation = pointsArray[currentIndex].rotation;
            if(pointsArray[currentIndex].gameObject.GetComponent<PlaceTrap>().trapActive == true)
            {
                trapped = true;
            }

            currentIndex = (currentIndex + 1) % pointsArray.Length;
        }
    }

    public void Interact()
    {
        if(trapped == true)
        {

        }
    }
}
