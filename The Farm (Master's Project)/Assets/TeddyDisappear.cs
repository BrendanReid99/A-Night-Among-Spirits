using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyDisappear : MonoBehaviour
{

    public GameObject teddyBear;
    float timePassed;
    float thresholdTime = 3.0f;
    //bool isTeddyVisible = true;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > thresholdTime) {
            teddyBear.SetActive(false);
            //isTeddyVisible = false;
        }
    }
}
