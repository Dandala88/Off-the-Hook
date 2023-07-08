using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private float strength;

    private void OnTriggerStay(Collider other)
    {
        var fish = other.GetComponent<FishController>();
        if (fish != null)
            fish.currentForce = direction * strength;
    }

    private void OnTriggerExit(Collider other)
    {
        var fish = other.GetComponent<FishController>();
        if (fish != null)
            fish.currentForce = Vector3.zero;
    }
}
