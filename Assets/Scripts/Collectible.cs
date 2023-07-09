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
    private Vector3 fleeDirection;

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
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        var distance = !flee ? idleMoveDistance : idleMoveDistance * 2;
        var dir = !flee ? Extensions.RandomVector3() : -fleeDirection;
        rb.AddForce(dir * distance);
        transform.forward = -dir;
        yield return new WaitForSeconds(idleMoveTime);
        StartCoroutine(Move());
    }

    private void OnTriggerEnter(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if (fish != null)
        {
            flee = true;
            fleeDirection = fish.transform.position - transform.position;
        }
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
