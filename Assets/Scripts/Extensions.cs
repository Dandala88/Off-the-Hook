using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Extensions
{
    public static Vector3 RandomVector3()
    {
        var x = Random.Range(-1, 2);
        var y = Random.Range(-1, 2);
        var z = Random.Range(-1, 2);
        return new Vector3(x, y, z);
    }

}
