using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyButtonSizer : MonoBehaviour
{
    public GameObject buttonSelectHighlight;
    public void SelectButton()
    {
        buttonSelectHighlight.SetActive(true);
    }
    public void DeselectButton()
    {
        buttonSelectHighlight.SetActive(false);
    }
}
