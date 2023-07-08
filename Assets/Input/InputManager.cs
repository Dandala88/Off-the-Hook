using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private FishController fish;
    [SerializeField] 
    private CameraController cameraController;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cameraController.Rotate(context.ReadValue<Vector2>());
        }
    }

    public void Swim(InputAction.CallbackContext context)
    {
        if(context.started)
            fish.Swim(true);

        if(context.canceled)
            fish.Swim(false);
    }

    public void Brake(InputAction.CallbackContext context)
    {
        if (context.started)
            fish.Brake(true);

        if (context.canceled)
            fish.Brake(false);
    }
}
