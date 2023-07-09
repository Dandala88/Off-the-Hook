using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private FishController fish;
    [SerializeField] 
    private CameraController cameraController;

    private PlayerInput playerInput;

    private static InputManager instance;

    public static InputManager Instance { get { return instance; } }

    public static Vector2 mouseSensitivity;
    public static bool invertY;

    public GameObject pauseMenu;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        invertY = true;
    }

    private void LockMouse(bool lck)
    {
        if(!lck)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void onEnable()
    {
        invertY = PlayerPrefs.GetInt("invertY", 0) == 1;
        var mouseFloat = PlayerPrefs.GetFloat("mouseSens", 1f);
        mouseSensitivity = new Vector2(mouseFloat, mouseFloat);
    }
    
    public void ChangeMouseSettings(Vector2 mouseSens, bool invY)
    {
        mouseSensitivity = mouseSens;
        invertY = invY;
        playerInput.actions["Rotate"].ApplyParameterOverride((ScaleVector2Processor p) => p.x, mouseSensitivity.x);
        playerInput.actions["Rotate"].ApplyParameterOverride((ScaleVector2Processor p) => p.x, mouseSensitivity.y);
        playerInput.actions["Rotate"].ApplyParameterOverride((InvertVector2Processor p) => p.invertY, invertY);
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

    public void Resume()
    {
        GameManager.Instance.isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        LockMouse(false);
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameManager.Instance.isPaused = !GameManager.Instance.isPaused;
            if(GameManager.Instance.isPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            pauseMenu.SetActive(GameManager.Instance.isPaused);
            LockMouse(GameManager.Instance.isPaused);
        }
    }
}
