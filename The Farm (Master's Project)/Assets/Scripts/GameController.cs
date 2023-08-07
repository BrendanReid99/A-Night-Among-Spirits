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
    public bool headDownstairs = false;
    public bool checkDoor = false;
    public bool teddyCollected = false;

    public int flyPapersCollected = 0;
    

    private float fadeDuration = 1f;

    public TextMeshProUGUI EnterHouseText;
    public TextMeshProUGUI FindBedroomKeyText;
    public TextMeshProUGUI ExploreHouseText;
    public TextMeshProUGUI InvestigateBangingText;
    public TextMeshProUGUI CheckCarText;
    public TextMeshProUGUI TurnBreakerText;
    public TextMeshProUGUI FlypaperText;
    public TextMeshProUGUI CatchTeddyText;

    public TextMeshProUGUI currentObjective;

    [SerializeField] public TextMeshProUGUI[] textArray;
    private int arrayPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentObjective = textArray[arrayPosition];
            currentObjective.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            currentObjective.gameObject.SetActive(false);
        }
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
        arrayPosition++;
        Debug.Log("Objective2");
        StartCoroutine(FindBedroomKey());
    }

    public void Objective3()
    {
        arrayPosition++;
        Debug.Log("Objective3");
        StartCoroutine(ExploreHouse());
    }

    public void Objective4()
    {
        arrayPosition++;
        Debug.Log("Objective4");
        StartCoroutine(InvestigateBanging());
        headDownstairs = true;
        checkDoor = true;
    }

    public void Objective5()
    {
        arrayPosition++;
        Debug.Log("Objective5");
        StartCoroutine(CheckCar());
        
    }

    public void Objective6()
    {
        arrayPosition++;
        Debug.Log("Objective6");
        StartCoroutine(TurnBreakerOn());
    }

    public void CatchTeddy()
    {
        Debug.Log("Teddy Caught");
        StartCoroutine(TeddyCaught());
        teddyCollected = true;
        
    }

    private IEnumerator EnterHouse()
    {
        EnterHouseText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = EnterHouseText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            EnterHouseText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        EnterHouseText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        EnterHouseText.gameObject.SetActive(false);
        EnterHouseText.color = startColor;

    }

    private IEnumerator FindBedroomKey()
    {

        yield return new WaitForSeconds(4);

        FindBedroomKeyText.gameObject.SetActive(true);

        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = FindBedroomKeyText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            FindBedroomKeyText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        FindBedroomKeyText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        FindBedroomKeyText.gameObject.SetActive(false);
        FindBedroomKeyText.color = startColor;


    }

    private IEnumerator ExploreHouse()
    {
        yield return new WaitForSeconds(1);

        ExploreHouseText.gameObject.SetActive(true); 


        float elapsedTime = 0f;

        yield return new WaitForSeconds(3f) ;

        Color startColor = ExploreHouseText.color;

        while(elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            ExploreHouseText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime+= Time.deltaTime;
            yield return null;
        }

        ExploreHouseText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        ExploreHouseText.gameObject.SetActive(false);
        ExploreHouseText.color = startColor;
    }

    private IEnumerator InvestigateBanging()
    {
        yield return new WaitForSeconds(1);

        InvestigateBangingText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(3f);

        Color startColor = InvestigateBangingText.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            InvestigateBangingText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        InvestigateBangingText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        InvestigateBangingText.gameObject.SetActive(false);
        InvestigateBangingText.color = startColor;
    }

    private IEnumerator CheckCar()
    {
        CheckCarText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = CheckCarText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            CheckCarText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            
           elapsedTime += Time.deltaTime;
           yield return null;
        }

        CheckCarText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        CheckCarText.gameObject.SetActive(false);
        CheckCarText.color = startColor;

    }

    private IEnumerator TurnBreakerOn()
    {
        TurnBreakerText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = TurnBreakerText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            TurnBreakerText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        TurnBreakerText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        TurnBreakerText.gameObject.SetActive(false);
        TurnBreakerText.color = startColor;
    }

    public void CollectFlypaper()
    {

        flyPapersCollected++;
        StartCoroutine(FlypaperCollected());
    }
    
    private IEnumerator FlypaperCollected()
    {
        FlypaperText.gameObject.SetActive(true);
        if(flyPapersCollected == 1)
        {
            FlypaperText.text = "You've collected a strip of flypaper - perhaps you could fashion a sticky trap.";
        }
        else if (flyPapersCollected > 1)
        {
            FlypaperText.text = "You've collected " + flyPapersCollected + " strips of flypaper.";
        }
        

        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = FlypaperText.color;

        while(elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            FlypaperText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;

        }

        FlypaperText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    private IEnumerator TeddyCaught()
    {
        CatchTeddyText.gameObject.SetActive(true);


        float elapsedTime = 0f;

        yield return new WaitForSeconds(5);

        Color startColor = CatchTeddyText.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            CatchTeddyText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        CatchTeddyText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    


}
