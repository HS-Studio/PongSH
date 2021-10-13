using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class close : MonoBehaviour
{
    private DefaultInputActions _quit;
    private InputAction Quit;

    private void OnEnable()
    {
        _quit = new DefaultInputActions();
        Quit = _quit.UI.Pause;
        Quit.performed += Close;

        Quit.Enable();
    }

    private void OnDisable()
    {
        Quit.Disable();
    }

    void Close(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
