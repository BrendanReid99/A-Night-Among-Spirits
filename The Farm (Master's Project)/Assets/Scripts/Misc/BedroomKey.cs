using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedroomKey : MonoBehaviour, IInteractable
{
    //Variable assignments
    public GameObject controller;
    private GameController gameController;

    public GameObject child;

    public TextMeshProUGUI bedroomKeyPickup;
    public GameObject bedroomKey;
    public float fadeDuration = 1f;
    
    void Start()
    {
        gameController = controller.GetComponent<GameController>();
    }

    //'picks up' the key when interacted with, disables mesh of tag and destroys child (key is child of tag).
    public void Interact()
    {
        Debug.Log("Bedroom Key Picked Up");
        StartCoroutine(keyPickup());
        bedroomKey.GetComponent<MeshRenderer>().enabled = false;
        Destroy(child);
        gameController.playerBedroomKeyPickup();
        
    }

    //Displays text indicating key has been picked up, destroys the entire key object at the end.
    private IEnumerator keyPickup()
    {
        bedroomKeyPickup.gameObject.SetActive(true);
       
        yield return new WaitForSeconds(3);
        
        float elapsedTime = 0f;
        Color startColor = bedroomKeyPickup.color;
        
        while(elapsedTime < fadeDuration)
        {
            
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            bedroomKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        bedroomKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        Destroy(bedroomKey);

    }
}
