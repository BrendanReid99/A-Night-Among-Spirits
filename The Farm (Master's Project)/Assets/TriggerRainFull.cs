using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TriggerRainFull : MonoBehaviour
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
        weather.GetComponent<AudioSource>().volume = 1.0f; //dampens the volume of the weather whilst inside the house
    }
}
