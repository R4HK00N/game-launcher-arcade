using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDetailsFromBrowser : MonoBehaviour
{
    public NewGameDetector newGameDetector;
    public void OpenGamePage()
    {
        GameObject gameDetails = newGameDetector.gamedetails;
        GameObject gameBrowser = newGameDetector.gamesBrowser;
        GameObject buttonPressed = this.gameObject;

        gameDetails.SetActive(true);
        gameBrowser.SetActive(false);
        buttonPressed.GetComponent<OnlyButtonSizer>().DeselectButton();
        if (EventSystem.current.currentSelectedGameObject.GetComponent<ButtonInfo>().GetIndex() != -1)
        {
            newGameDetector.DisplayGameInfo(EventSystem.current.currentSelectedGameObject.GetComponent<ButtonInfo>().GetIndex());
        }
        GameObject playButton = newGameDetector.playButton;
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}
