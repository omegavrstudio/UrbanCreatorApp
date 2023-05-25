using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using OmegaStudio.Core.Patterns;

[DefaultExecutionOrder(-1)]
public class InputManagerAR : Singleton<InputManagerAR>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    private InputAction_AR inputAction_AR;

    private void Awake()
    {
        inputAction_AR = new InputAction_AR();
    }

    private void OnEnable()
    {
        inputAction_AR.Enable();
    }

    private void OnDisable()
    {
        inputAction_AR.Disable();
    }

    void Start()
    {
        inputAction_AR.Touch.TouchPress.started += ctx => StartTouch(ctx);
        inputAction_AR.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if(OnStartTouch != null)
        {
            OnStartTouch(inputAction_AR.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(inputAction_AR.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }
}
