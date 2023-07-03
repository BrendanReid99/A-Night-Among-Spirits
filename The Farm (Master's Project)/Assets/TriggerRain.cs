using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRain : MonoBehaviour
{
    public AudioClip rain;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = rain;
    }
    void OnTriggerEnter(Collision collision)
    {
        Debug.Log("Collision");
        GetComponent<AudioSource>().Stop();
    }
}
