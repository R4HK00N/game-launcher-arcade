using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenAdmin : MonoBehaviour
{
    public GameObject adminLogin;
    public GameObject gameBrowser;
    public GameObject adminPanel;
    public GameObject loginButton;
    public GameObject highlightButton;
    public GameObject gamesButton;
    public TMP_InputField password;
    string adminPassword = "monke";
    public bool canGoBackAdmin;
    public bool passwordIsCorrect;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            EventSystem.current.SetSelectedGameObject(loginButton);
            adminLogin.SetActive(true);
            gameBrowser.SetActive(false);
        }
    }
    public void OnGoBack()
    {
        if(canGoBackAdmin)
        {
            EventSystem.current.SetSelectedGameObject(highlightButton);
            adminLogin.SetActive(false);
            gameBrowser.SetActive(true);
        }
    }
    public void SetLoginButtonSelected()
    {
        EventSystem.current.SetSelectedGameObject(loginButton);
    }
    public void TestLogin()
    {
        if(password.text == PlayerPrefs.GetString("password"))
        {
            passwordIsCorrect = true;
        }
    }
    public void LoginButton()
    {
        if(passwordIsCorrect)
        {
            EventSystem.current.SetSelectedGameObject(gamesButton);
            password.text = "";
            adminPanel.SetActive(true);
            adminLogin.SetActive(false);
            passwordIsCorrect = false;
        }
    }
    public void CanGoBackToBrowser()
    {
        canGoBackAdmin = true;
    }
    public void CanNotGoBackToBrowser()
    {
        canGoBackAdmin = false;
    }
}
