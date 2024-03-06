using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UpAndDownAnimation : MonoBehaviour
{
    public InputAction controller;
    public Animator animator;
    public bool scrolledDown;
    public bool scrollDownAllowed;
    public bool scrolledUp = true;
    public bool scrollUpAllowed;
    public Button upperLeft;
    public Button highlight;

    public void OnScrollDown()
    {
        if(scrollDownAllowed)
        {
            if(!scrolledDown)
            {
                scrolledDown = true;
                animator.SetTrigger("ScrollDown");
                scrolledUp = false;
            }
        }
    }
    public void OnScrollUp()
    {
        if(scrollUpAllowed)
        {
            if (!scrolledUp)
            {
                scrolledUp = true;
                animator.SetTrigger("ScrollUp");
                scrolledDown = false;
            }
        }
    }
    public void CanScrollDown()
    {
        scrollDownAllowed = true;
    }
    public void CanNotScrollDown()
    {
        scrollDownAllowed = false;
    }
    public void CanScrollUp()
    {
        scrollUpAllowed = true;
    }
    public void CanNotScrollUp()
    {
        scrollUpAllowed = false;
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
