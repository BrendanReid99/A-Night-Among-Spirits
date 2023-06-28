using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasementKey : MonoBehaviour, IInteractable
{
    public GameObject controller;
    private GameController gameController;

    public GameObject child;

    public TextMeshProUGUI basementKeyPickup;
    public GameObject basementKey;
    public float fadeDuration = 1f;

    void Start()
    {
        gameController = controller.GetComponent<GameController>();
    }


    public void Interact()
    {
        Debug.Log("Basement Key Picked Up");
        StartCoroutine(keyPickup());
        basementKey.GetComponent<MeshRenderer>().enabled = false;
        Destroy(child);
        gameController.basementKeyPickup();

    }

    private IEnumerator keyPickup()
    {
        basementKeyPickup.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        float elapsedTime = 0f;
        Color startColor = basementKeyPickup.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            basementKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }

        basementKeyPickup.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        Destroy(basementKey);

    }
}