using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Collectible
{
    protected override void Captured(FishController fish)
    {
        base.Captured(fish);
        Debug.Log("EATME");
    }
}
