using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpAndDownAnimation : MonoBehaviour
{
    public InputAction controller;
    public Animator animator;
    public bool scrolledDown;
    public bool scrolledUp = true;

    public void OnScrollDown()
    {
        if(!scrolledDown)
        {
            scrolledDown = true;
            animator.SetTrigger("ScrollDown");
            scrolledUp = false;
        }
    }
    public void OnScrollUp()
    {
        if (!scrolledUp)
        {
            scrolledUp = true;
            animator.SetTrigger("ScrollUp");
            scrolledDown = false;
        }
    }

    private void OnEnable()
    {
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.Disable();
    }
}
