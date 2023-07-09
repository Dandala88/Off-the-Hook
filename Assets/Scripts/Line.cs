using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{
    [SerializeField]
    private float caughtDistance;
    [HideInInspector]
    public Vector3 lineEntry;
    [HideInInspector]
    public Transform bait;
    [SerializeField]
    private float gracePeriod;
    
    private LineRenderer lineRenderer;

    private float t;

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
            if (lineEntry.y - bait.position.y < caughtDistance && t >= gracePeriod)
            {
                GameManager.Instance.calories = 0;
                FishController.caught = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            t += Time.deltaTime;
        }
        else
        {
            t = 0;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
