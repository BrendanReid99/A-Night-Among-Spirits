using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour
{

    public GameObject GameController;
    private GameController controller;


    private CameraShaker shake;
    private bool _once = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.GetComponent<GameController>();
        shake = this.GetComponent<CameraShaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(_once == false && controller.headDownstairs == true)
        {
            shake.shakeCamera();
            _once = true;
        }
        else if (controller.headDownstairs == true)
        {
            Destroy(this);
        }
        
    }


}
