using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Collectible
{
    [SerializeField]
    private float idleMoveTime;
    [SerializeField]
    private float idleMoveDistance;

    private Rigidbody rb;
    private bool flee;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        var distance = flee ? idleMoveDistance : idleMoveDistance * 10;
        var time = flee ? idleMoveTime : idleMoveTime * 3;
        rb.AddForce(Extensions.RandomVector3() * distance);
        yield return new WaitForSeconds(time);
        StartCoroutine(Move());
    }

    private void OnTriggerEnter(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if(fish != null)
            flee = true;
    }

    private void OnTriggerStay(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if (fish != null)
        {
            float dist = Vector3.Distance(fish.transform.position, transform.position);
            if (dist < fish.eatDistance)
                Debug.Log("EATME");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FishController fish = other.GetComponent<FishController>();
        if (fish != null)
            flee = false;
    }
}
