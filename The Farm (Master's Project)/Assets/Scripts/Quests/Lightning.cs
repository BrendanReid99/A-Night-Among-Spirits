using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    private float timer = 0.0f;
    private float interval = 0.0f;

    //[SerializeField] private GameObject directionalLight;

    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        interval = Random.Range(25.0f, 75.0f);
        Debug.Log(interval);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > interval)
        {
            Debug.Log("Lightning flash!");
            StartCoroutine(lightningFlash());
            timer = 0.0f;
            interval = Random.Range(25.0f, 75.0f);
        }
    }

    private IEnumerator lightningFlash()
    {
        yield return new WaitForSeconds(0.5f);

        light.intensity = 2.5f;

        yield return new WaitForSeconds(0.1f);

        light.intensity = 0.0f;

        yield return new WaitForSeconds(0.2f);

        light.intensity = 2.5f;

        yield return new WaitForSeconds(0.25f);

        light.intensity = 0.0f;
    }
}
