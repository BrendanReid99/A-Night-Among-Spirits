using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedroomKey : MonoBehaviour, IInteractable
{

    public TextMeshProUGUI bedroomKeyPickup;
    public GameObject bedroomKey;
    public float fadeDuration = 1f;
    

    public void Interact()
    {
        Debug.Log("Bedroom Key Picked Up");
        StartCoroutine(keyPickup());
        bedroomKey.GetComponent<MeshRenderer>().enabled = false;
        
    }

    private IEnumerator keyPickup()
    {
        bedroomKeyPickup.gameObject.SetActive(true);
        Debug.Log("1");
        yield return new WaitForSeconds(3);
        Debug.Log("2");
        float elapsedTime = 0f;
        Color startColor = bedroomKeyPickup.color;
        Debug.Log("3");
        while(elapsedTime < fadeDuration)
        {
            Debug.Log("4");
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            bedroomKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }
        Debug.Log("5");
        bedroomKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        Destroy(bedroomKey);

    }
}
