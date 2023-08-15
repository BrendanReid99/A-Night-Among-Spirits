using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRain : MonoBehaviour
{
    [SerializeField] private GameObject weather;
    public AudioClip rain;

    void Start()
    {
        weather.GetComponent<AudioSource>().playOnAwake = false;
        weather.GetComponent<AudioSource>().clip = rain;
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision");
        weather.GetComponent<AudioSource>().volume = 0.20f; //dampens the volume of the weather whilst inside the house
    }
}
