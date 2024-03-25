using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtenSizer : MonoBehaviour
{
    public Vector3 startButtonSize;
    public GameObject buttonSelectHighlight;
    public bool doSelectHighlight;

    public void Start()
    {
        startButtonSize = transform.localScale;
    }
    public void SelectButton()
    {
        transform.localScale *= 1.1f;
        if (doSelectHighlight == true)
        {
            buttonSelectHighlight.SetActive(true);
        }
    }
    public void DeselectButton()
    {
        transform.localScale = startButtonSize;
        if (doSelectHighlight == true)
        {
            buttonSelectHighlight.SetActive(false);
        }
    }
}
