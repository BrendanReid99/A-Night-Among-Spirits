using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public bool playerBedroomKey = false;
    public bool basementDoorKey = false;
    public bool bedroom2Open = false;
    public bool bedroom3Open = false;

    private float fadeDuration = 1f;

    public TextMeshProUGUI EnterHouseText;
    public TextMeshProUGUI FindBedroomKeyText;
    public TextMeshProUGUI ExploreHouseText;
    public TextMeshProUGUI InvestigateBangingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerBedroomKeyPickup()
    {
        playerBedroomKey = true;
    }

    public void basementKeyPickup()
    {
        basementDoorKey = true;
    }

    public void Objective1()
    {
        Debug.Log("Objective1");
        StartCoroutine(EnterHouse());
    }

    public void Objective2()
    {
        Debug.Log("Objective2");
        StartCoroutine(FindBedroomKey());
    }

    public void Objective3()
    {
        Debug.Log("Objective3");
        StartCoroutine(ExploreHouse());
    }

    public void Objective4()
    {
        Debug.Log("Objective4");
        StartCoroutine(InvestigateBanging());
    }

    private IEnumerator EnterHouse()
    {
        EnterHouseText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(3);

        Color startColor = EnterHouseText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            EnterHouseText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        EnterHouseText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);


    }

    private IEnumerator FindBedroomKey()
    {

        yield return new WaitForSeconds(4);

        FindBedroomKeyText.gameObject.SetActive(true);



        float elapsedTime = 0f;

        yield return new WaitForSeconds(3);

        Color startColor = FindBedroomKeyText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            FindBedroomKeyText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        FindBedroomKeyText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

    }

    private IEnumerator ExploreHouse()
    {
        yield return new WaitForSeconds(1);

        ExploreHouseText.gameObject.SetActive(true); 


        float elapsedTime = 0f;

        yield return new WaitForSeconds(0.5f);

        Color startColor = ExploreHouseText.color;

        while(elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            ExploreHouseText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime+= Time.deltaTime;
            yield return null;
        }

        ExploreHouseText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    private IEnumerator InvestigateBanging()
    {
        yield return new WaitForSeconds(1);

        InvestigateBangingText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(0.5f);

        Color startColor = InvestigateBangingText.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            InvestigateBangingText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        InvestigateBangingText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

}
