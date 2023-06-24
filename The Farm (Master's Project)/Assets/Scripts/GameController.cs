using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool playerBedroomKey = false;
    public bool basementDoorKey = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerBedroomKeyPickup()
    {
        playerBedroomKey = true;
    }

    public void basementKeyPickup()
    {
        basementDoorKey = true;
    }


}
