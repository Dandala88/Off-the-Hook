using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BaitItem : Collectible
{
    [SerializeField]
    private float topWaterRadius;
    [SerializeField]
    private float reelForce;
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("Determines screenshake.")]
    private float hookSetPower;

    private Line line;
    private Vector3 lineEntry;

    protected override void Awake()
    {
        base.Awake();
        line = FindObjectOfType<Line>();
    }

    protected override void Captured(FishController fish)
    {
        base.Captured(fish);
        float rollAngle = Random.Range(0f, 360f);
        float x = Mathf.Cos(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        float y = Mathf.Sin(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        line.lineEntry = new Vector3(x, topWater.transform.position.y, y);
        line.bait = transform;

        StopCoroutine(movementCoroutine);
        transform.parent = fish.transform;
        FishController.caught = true;
        StartCoroutine(cam.Shake(hookSetPower / 100));
        fish.currentSpeed = 0;
        fish.caughtLineEntry = line.lineEntry;
        Vector3 heading = line.lineEntry - transform.position;
        Debug.DrawRay(transform.position, heading.normalized, Color.yellow, 5);
        fish.reelForce = heading.normalized * reelForce;
    }
}
