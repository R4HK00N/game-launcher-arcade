using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject gameBrowser;
    public GameObject settings;
    public GameObject volumeButton;
    public GameObject highlightButton;
    public bool canGoBack;
    public bool canGoBackBrowser;
    public void GoToSettings()
    {
        gameBrowser.SetActive(false);
        settings.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volumeButton);
    }
    public void OnGoBack()
    {
        if(canGoBack)
        {
            EventSystem.current.SetSelectedGameObject(volumeButton);
        }
        else
        {
            gameBrowser.SetActive(true);
            settings.SetActive(false);
            EventSystem.current.SetSelectedGameObject(highlightButton);
        }
    }
    public void CanGoBackVolume()
    {
        canGoBack = true;
    }
    public void CanNotGoBackVolume()
    {
        canGoBack = false;
    }
    public void CanGoBackToBrowser()
    {
        canGoBackBrowser = true;
    }
    public void CanNotGoBackToBrowser()
    {
        canGoBackBrowser = false;
    }
}
