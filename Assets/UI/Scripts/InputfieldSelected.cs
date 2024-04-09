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
    public bool searchFunction;
    public TMP_InputField searchField;
    public void InputFieldButton()
    {
        selectImage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(inputfield);
        if(searchFunction == true)
        {
            searchField.GetComponent<TMP_InputField>().enabled = true;
        }
    }
    public void OnInputfieldSelected()
    {
        selectImage.SetActive(true);
    }
    public void OnInputfieldDeselected()
    {
        selectImage.SetActive(false);
        if(searchFunction == true)
        {
            placeholder.text = "Search game...";
            searchField.GetComponent<TMP_InputField>().enabled = false;
            searchFunction = false;
        }
        else
        {
            placeholder.text = "Enter new password...";
        }
    }
    public void CanWriteDown()
    {
        placeholder.text = "...";
    }
}
