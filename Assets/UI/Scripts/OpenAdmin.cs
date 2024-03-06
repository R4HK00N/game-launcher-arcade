using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenAdmin : MonoBehaviour
{
    public GameObject adminLogin;
    public GameObject gameBrowser;
    public GameObject loginButton;
    public GameObject highlightButton;
    public bool canGoBackAdmin;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            adminLogin.SetActive(true);
            gameBrowser.SetActive(false);
            EventSystem.current.SetSelectedGameObject(loginButton);
        }
    }
    public void OnGoBack()
    {
        if(canGoBackAdmin)
        {
            adminLogin.SetActive(false);
            gameBrowser.SetActive(true);
            EventSystem.current.SetSelectedGameObject(highlightButton);
        }
    }
    public void AdminCanGoBAck()
    {
        canGoBackAdmin = true;
    }
    public void AdminCanNotGoBAck()
    {
        canGoBackAdmin = false;
    }
}
