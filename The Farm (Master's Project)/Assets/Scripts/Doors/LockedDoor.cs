using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//FOR BASEMENT DOORS - ALL LOCKED

public class LockedDoor : MonoBehaviour, IInteractable
{

    //Variable assignments
    public TextMeshProUGUI locked;
    private float fadeDuration = 4f;

    
    void Start()
    {
       
    }

    //Displays 'locked' text when door is interacted with.
    public void Interact()
    { 
        StartCoroutine(doorLocked());
    }

    private IEnumerator doorLocked()
    {
        locked.gameObject.SetActive(true);



        float elapsedTime = 0f;
        Color startColor = locked.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            locked.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        locked.color = new Color(startColor.r, startColor.g, startColor.b, 0f);


    }
}
