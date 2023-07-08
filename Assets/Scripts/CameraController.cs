using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float maxYRotate;
    [SerializeField]
    private float maxXRotate;

    private Vector2 currentRotation;
    private Vector2 rotateInput;

    private void LateUpdate()
    {
        currentRotation.x += rotateInput.x;
        currentRotation.y += rotateInput.y;
        if (Mathf.Abs(currentRotation.y) > maxYRotate) currentRotation.y = maxYRotate * Mathf.Sign(currentRotation.y);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }

    public void Rotate(Vector2 rotateInput)
    {
        this.rotateInput = rotateInput;
    }
}
