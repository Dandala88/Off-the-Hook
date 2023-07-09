using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private float caughtDistance;
    [HideInInspector]
    public Vector3 lineEntry;
    [HideInInspector]
    public Transform bait;
    
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        if (bait != null)
        {
            lineRenderer.SetPosition(0, bait.position);
            lineRenderer.SetPosition(1, lineEntry);
            if (Vector3.Distance(bait.position, lineEntry) < caughtDistance)
                Debug.Log("DEAD");
        }
        else
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
