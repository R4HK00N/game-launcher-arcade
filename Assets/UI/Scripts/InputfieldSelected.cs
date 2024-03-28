using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputfieldSelected : MonoBehaviour
{
    public GameObject inputfield;
    public GameObject selectImage;
    public TMP_Text placeholder;

    public void InputFieldButton()
    {
        selectImage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(inputfield);
    }
    public void OnInputfieldSelected()
    {
        selectImage.SetActive(true);
    }
    public void OnInputfieldDeselected()
    {
        selectImage.SetActive(false);
        placeholder.text = "Enter new password...";
    }
    public void CanWriteDown()
    {
        placeholder.text = "...";
    }
}
