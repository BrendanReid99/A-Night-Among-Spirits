using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCreaking : MonoBehaviour
{
    private float timer = 0.0f;
    private float interval = 0.0f;

    //[SerializeField] private GameObject directionalLight;

    public AudioSource woodCreak;

    // Start is called before the first frame update
    void Start()
    {
        woodCreak = GetComponent<AudioSource>();
        interval = Random.Range(25.0f, 75.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            Debug.Log("Wood Creak TRUE");
            StartCoroutine(woodCreaking());
            timer = 0.0f;
            interval = Random.Range(25.0f, 75.0f);
        }
    }

    private IEnumerator woodCreaking()
    {
        yield return new WaitForSeconds(5.0f);

        woodCreak.Play();

    }
}
