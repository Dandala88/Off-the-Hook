using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform follow;

    private void LateUpdate()
    {
        transform.forward = follow.forward;
        transform.position = follow.position;
    }
}
