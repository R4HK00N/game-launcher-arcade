using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtenSizer : MonoBehaviour
{
    public Vector3 startButtonSize;
    public GameObject buttonSelectHighlight;

    public void Start()
    {
        startButtonSize = transform.localScale;
    }
    public void SelectButton()
    {
        buttonSelectHighlight.SetActive(true);
        transform.localScale *= 1.1f;
    }
    public void DeselectButton()
    {
        buttonSelectHighlight.SetActive(false);
        transform.localScale = startButtonSize;
    }
}
