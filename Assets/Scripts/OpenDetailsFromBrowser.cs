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

        gameDetails.SetActive(true);
        gameBrowser.SetActive(false);
        if (EventSystem.current.currentSelectedGameObject.GetComponent<ButtonInfo>().GetIndex() != -1)
        {
            newGameDetector.DisplayGameInfo(EventSystem.current.currentSelectedGameObject.GetComponent<ButtonInfo>().GetIndex());
        }
        GameObject playButton = newGameDetector.playButton;
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}
