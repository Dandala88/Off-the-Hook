using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private float idleMoveTime;
    [SerializeField]
    private float idleMoveDistance;

    private Rigidbody rb;
    private bool flee;
    protected bool captured;
    protected IEnumerator movementCoroutine;
    protected CameraController cam;
    protected TopWater topwater;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraController>();
    }

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        topwater = FindObjectOfType<TopWater>();
        movementCoroutine = Move();
        StartCoroutine(movementCoroutine);
    }

    private IEnumerator Move()
    {
        var distance = flee ? idleMoveDistance : idleMoveDistance * 10;
        var time = flee ? idleMoveTime : idleMoveTime * 3;
        rb.AddForce(Extensions.RandomVector3() * distance);
        yield return new WaitForSeconds(time);
        StartCoroutine(movementCoroutine);
    }

    private void OnTriggerEnter(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if (fish != null)
            flee = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!captured && !FishController.caught)
        {
            FishController fish = other.GetComponent<FishController>();
            if (fish != null)
            {
                float dist = Vector3.Distance(fish.transform.position, transform.position);
                if (dist < fish.eatDistance)
                    Captured(fish);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if (fish != null)
            flee = false;
    }

    protected virtual void Captured(FishController fish)
    {
        captured = true;
    }
}
