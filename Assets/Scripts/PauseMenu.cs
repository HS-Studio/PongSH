using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;

    private DefaultInputActions _quit;
    private InputAction Quit;

    [SerializeField]
    GameObject PauseManu;

    void Start()
    {
        isPaused = false;
        PauseManu.SetActive(false);
    }

    private void OnEnable()
    {
        _quit = new DefaultInputActions();
        Quit = _quit.UI.Pause;
        Quit.performed += Quitction;

        Quit.Enable();
    }

    private void OnDisable()
    {
        Quit.Disable();
    }

    public void Quitction(InputAction.CallbackContext context)
    {
        PauseResume();
    }

    public void PauseResume()
    {
        if(isPaused)
        {
            isPaused = false;
            PauseManu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            PauseManu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
