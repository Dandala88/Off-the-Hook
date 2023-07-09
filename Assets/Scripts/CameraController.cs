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
    [SerializeField]
    private float rotateSpeed;

    private Vector2 currentRotation;
    private Vector2 rotateInput;

    private bool started;

    private void Start()
    {
        currentRotation = new Vector2(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x);
    }

    private void LateUpdate()
    {
        currentRotation.x += rotateInput.x * Time.deltaTime * rotateSpeed;
        currentRotation.y += rotateInput.y * Time.deltaTime * rotateSpeed;
        if (Mathf.Abs(currentRotation.y) > maxYRotate) currentRotation.y = maxYRotate * Mathf.Sign(currentRotation.y);

        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

        if (!FishController.caught)
            transform.position = follow.position + offset;
    }

    public void Rotate(Vector2 rotateInput)
    {
        this.rotateInput = rotateInput;
    }

    public IEnumerator Shake(float magnitude)
    {
        Vector3 orignalPosition = transform.position;

        while (FishController.caught)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = follow.position + offset + new Vector3(x, y, 0f);
            yield return null;
        }
        transform.position = orignalPosition;
    }
}
