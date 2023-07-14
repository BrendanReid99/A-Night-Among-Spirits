using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyTeleport : MonoBehaviour
{
    [SerializeField] private Transform[] pointsArray;
    [SerializeField] private GameObject teddy;
    private float teleportInterval = 20f;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TeleportTeddy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TeleportTeddy()
    {
        while (true)
        {
            teddy.transform.position = pointsArray[currentIndex].position;
            teddy.transform.rotation = pointsArray[currentIndex].rotation;

            yield return new WaitForSeconds(teleportInterval);

            currentIndex = (currentIndex + 1) % pointsArray.Length;
        }
    }
}
