using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Collectible
{
    public int calories;

    protected override void Captured(FishController fish)
    {
        base.Captured(fish);
        GameManager.Instance.calories += calories;
        Destroy(gameObject);
    }
}
