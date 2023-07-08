using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        transform.forward = follow.forward;
        transform.position = follow.position + offset;
    }
}
