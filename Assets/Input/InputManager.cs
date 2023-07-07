using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private FishController fish;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            fish.Move(context.ReadValue<Vector2>());
        }
    }

    public void Swim(InputAction.CallbackContext context)
    {
        if(context.started)
            fish.Swim(true);

        if(context.canceled)
            fish.Swim(false);
    }

}
