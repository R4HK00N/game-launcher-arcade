using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class AdminPanel : MonoBehaviour
{
    public GameObject gameBrowser;
    public GameObject adminPanel;
    public GameObject highlightButton;
    public GameObject passwordPanel;
    public GameObject gamesPanel;
    public TMP_Text headLiner;
    public TMP_InputField oldPassword;
    public TMP_InputField newPassword;
    public TMP_InputField repeatNewPassword;
    public TMP_Text passwordChangeConfirmer;
    public TMP_Text oldPlaceholder, newPlaceholder, repeatPlaceholder;
    public bool oldPasswordIsCorrect;
    public bool newPasswordIsCorrect;

    public void Start()
    {
        Debug.Log(PlayerPrefs.GetString("password"));
    }
    public void LogOut()
    {
        oldPassword.text = "";
        newPassword.text = "";
        repeatNewPassword.text = "";
        gameBrowser.SetActive(true);
        adminPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(highlightButton);
    }
    public void ChangeToPasswordButton()
    {
        headLiner.text = "Password";
        passwordPanel.SetActive(true);
        gamesPanel.SetActive(false);
    }
    public void ChangeToGamesButton()
    {
        headLiner.text = "Games";
        passwordPanel.SetActive(false);
        gamesPanel.SetActive(true);
    }
    public void CheckOldPassword()
    {
        if(oldPassword.text == PlayerPrefs.GetString("password"))
        {
            oldPasswordIsCorrect = true;
        }
    }
    public void CheckNewPassword()
    {
        if(newPassword.text == repeatNewPassword.text)
        {
            newPasswordIsCorrect = true;
        }
    }
    public void ChangePassWord()
    {
        if (oldPassword.text == PlayerPrefs.GetString("password"))
        {
            oldPasswordIsCorrect = true;
        }
        if (newPassword.text == repeatNewPassword.text)
        {
            newPasswordIsCorrect = true;
        }
        if (newPasswordIsCorrect && oldPasswordIsCorrect)
        {
            passwordChangeConfirmer.color = Color.green;
            passwordChangeConfirmer.text = "The Password has been succesfully changed";
            StartCoroutine(HidePasswordConfirmer());
            PlayerPrefs.SetString("password", newPassword.text);
            Debug.Log("password changed");
            newPasswordIsCorrect = false;
            oldPasswordIsCorrect = false;
            oldPassword.text = "";
            newPassword.text = "";
            repeatNewPassword.text = "";
            oldPlaceholder.text = "Enter new password...";
            newPlaceholder.text = "Enter new password...";
            repeatPlaceholder.text = "Enter new password...";
        }
        else
        {
            passwordChangeConfirmer.color = Color.red;
            passwordChangeConfirmer.text = "The Old Or New password do not match";
            StartCoroutine(HidePasswordConfirmer());
            newPasswordIsCorrect = false;
            oldPasswordIsCorrect = false;
        }
    }
    public IEnumerator HidePasswordConfirmer()
    {
        yield return new WaitForSeconds(3);
        passwordChangeConfirmer.text = "";
    }
}
