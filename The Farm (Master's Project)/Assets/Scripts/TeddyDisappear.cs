using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyDisappear : MonoBehaviour
{

    public GameObject teddyBear;
    float timePassed;
    float thresholdTime = 3.0f;
    bool isTeddyVisible = true;

    [SerializeField] private GameObject teddyBearVoice;
    public AudioClip teddyVoice;

    void Start()
    {
        teddyBearVoice.GetComponent<AudioSource>().playOnAwake = false;
        teddyBearVoice.GetComponent<AudioSource>().clip = teddyVoice;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > thresholdTime && isTeddyVisible == true) {
            teddyBear.SetActive(false);
            isTeddyVisible = false;
            timePassed = 0;
            thresholdTime = Random.Range(2.0f, 8.0f);
        }

        else if (timePassed > thresholdTime && isTeddyVisible == false)
        {
            teddyBear.SetActive(true);
            isTeddyVisible = true;
            timePassed = 0;
            thresholdTime = Random.Range(2.0f, 8.0f);
            teddyBearVoice.GetComponent<AudioSource>().Play();
        }
        
    }
}
