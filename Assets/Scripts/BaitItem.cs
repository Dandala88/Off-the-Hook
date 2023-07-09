using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaitItem : Collectible
{
    [SerializeField]
    private float topWaterRadius;
    [SerializeField]
    private float reelForce;


    protected override void Captured(FishController fish)
    {
        base.Captured(fish);
        float rollAngle = Random.Range(0f, 360f);
        float x = Mathf.Cos(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        float y = Mathf.Sin(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        Vector3 lineEntry = new Vector3(x, topWater.transform.position.y, y);
        Debug.Log("Caught: " + lineEntry);
        Debug.DrawLine(transform.position, lineEntry, Color.magenta, 5);
        fish.transform.forward = lineEntry.normalized;
        fish.currentForce = lineEntry.normalized * reelForce;
        Camera.main.transform.forward = lineEntry.normalized;
    }
}
