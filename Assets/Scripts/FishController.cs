using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    [Tooltip("Higher the number the more sensitive")]
    [Min(0.01f)]
    private float rotationSensitivity;
    [SerializeField]
    private bool invertY;
    [SerializeField]
    private float mouseDeadZone;
    [SerializeField]
    private float mouseSpeed;
    [SerializeField]
    private float maxYRotate;

    private CharacterController characterController;
    private Vector2 input;
    private Vector3 movement;
    private float currentSpeed;
    private Vector2 currentRotation;

    bool swimming;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 mouse = new Vector2(Mouse.current.position.value.x - Screen.width / 2, Mouse.current.position.value.y - Screen.height / 2);
        if (Vector2.Distance(mouse, Vector2.zero) > mouseDeadZone)
            input = mouse * mouseSpeed * Time.deltaTime;
        else
            input = Vector2.zero;
            
        int inverted = invertY ? 1 : -1;
        currentRotation.y += input.y;
        currentRotation.x += input.x;
        if(Mathf.Abs(currentRotation.y) > maxYRotate) currentRotation.y = maxYRotate * Mathf.Sign(currentRotation.y);
        Debug.Log(currentRotation.y);
        transform.localRotation = Quaternion.Euler(currentRotation.y * inverted * rotationSensitivity, currentRotation.x * rotationSensitivity, 0f);
        currentSpeed = swimming ? currentSpeed + acceleration * Time.deltaTime : currentSpeed - acceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < 0) currentSpeed = 0;

        characterController.Move(transform.forward * currentSpeed * Time.deltaTime);
    }

    public void Move(Vector2 input)
    {
        this.input = input;
    }

    public void Swim(bool activated)
    {
        swimming = activated;
    }
}
