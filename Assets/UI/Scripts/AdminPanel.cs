using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdminPanel : MonoBehaviour
{
    public GameObject gameBrowser;
    public GameObject adminPanel;
    public GameObject highlightButton;
    public GameObject passwordPanel;
    public GameObject gamesPanel;
    public TMP_Text headLiner;
    public TMP_InputField newPassword;
    public void LogOut()
    {
        gameBrowser.SetActive(true);
        adminPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(highlightButton);
    }
    public void ChangeToPasswordButton()
    {
        passwordPanel.SetActive(true);
        gamesPanel.SetActive(false);
    }
    public void ChangeToGamesButton()
    {
        passwordPanel.SetActive(false);
        gamesPanel.SetActive(true);
    }
    public void ChangePassWord()
    {
        PlayerPrefs.SetString("password", newPassword.text);
        Debug.Log("password changed");
    }
}
