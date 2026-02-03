using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class String : MonoBehaviour
{
    public LineRenderer lineRenderer;
    
    public GameObject firstPin;
    public GameObject secondPin;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.SetPosition(0, firstPin.transform.position);
        lineRenderer.SetPosition(1, secondPin.transform.position);
    }
}
