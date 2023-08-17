using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{

    [SerializeField] private GameObject footstepHolder;
    private Footsteps footsteps;

    // Start is called before the first frame update
    void Start()
    {
        footsteps = footstepHolder.GetComponent<Footsteps>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player on wood");
            footsteps.isWood = true;
        }
        
    }
    
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player on dirt");
            footsteps.isWood = false;
        }
    }

}
