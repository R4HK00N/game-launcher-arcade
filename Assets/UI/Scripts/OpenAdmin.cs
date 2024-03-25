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
        if(Input.GetKeyDown(KeyCode. Minus))
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
        else if(password.text == adminPassword)
        {
            passwordIsCorrect = true;
        }
        Debug.Log("can check");
    }
    public void LoginButton()
    {
        if(passwordIsCorrect)
        {
            password.text = "";
            adminPanel.SetActive(true);
            adminLogin.SetActive(false);
            passwordIsCorrect = false;
            EventSystem.current.SetSelectedGameObject(gamesButton);
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
