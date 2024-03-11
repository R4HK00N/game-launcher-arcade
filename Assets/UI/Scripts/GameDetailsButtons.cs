using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDetailsButtons : MonoBehaviour
{
    public GameObject gameBrowser;
    public GameObject gameDetails;
    public NewGameDetector newGameDetector;
    public bool goBackToBrowser;

    public void GameClick()
    {
        gameDetails.SetActive(true);
        gameBrowser.SetActive(false);
        newGameDetector.DisplayGameInfo();
    }
    public void OnGoBack()
    {
        if(goBackToBrowser)
        {
            gameDetails.SetActive(false);
            gameBrowser.SetActive(true);
        }
    }
    public void CanGoBackToBrowser()
    {
        goBackToBrowser = true;
    }
    public void CanNotGoBackToBrowser()
    {
        goBackToBrowser = false;
    }
}
