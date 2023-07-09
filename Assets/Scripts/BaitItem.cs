using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BaitItem : Collectible
{
    [SerializeField]
    private float topWaterRadius;
    
    public float reelForce;
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("Determines screenshake.")]
    private float hookSetPower;

    private Line line;

    protected override void Init()
    {
        base.Init();
        line = FindObjectOfType<Line>();
    }

    protected override void Captured(FishController fish)
    {
        base.Captured(fish);
        float rollAngle = Random.Range(0f, 360f);
        float x = Mathf.Cos(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        float y = Mathf.Sin(rollAngle * Mathf.Deg2Rad) * topWaterRadius;
        line.lineEntry = new Vector3(x, topwater.transform.position.y, transform.position.z + y);
        line.bait = transform;

        StopAllCoroutines();
        fish.caughtLineEntry = line.lineEntry;
        transform.parent = fish.transform;
        FishController.caught = true;
        StartCoroutine(cam.Shake(hookSetPower / 100));
        fish.currentSpeed = 0;
        Vector3 heading = line.lineEntry - transform.position;
        Debug.DrawRay(transform.position, heading.normalized, Color.yellow, 5);
        fish.reelForce = heading.normalized * reelForce;
    }
}
