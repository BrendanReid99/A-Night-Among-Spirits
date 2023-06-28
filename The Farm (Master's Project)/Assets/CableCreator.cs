using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCreator : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int numSegments = 20;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        CreateCable();
    }

    private void CreateCable()
    {
        lineRenderer.positionCount = numSegments + 1;

        for (int i = 0; i <= numSegments; i++)
        {
            float t = i / (float)numSegments;
            Vector3 position = Vector3.Lerp(startPoint.position, endPoint.position, t);
            lineRenderer.SetPosition(i, position);
        }
    }
}