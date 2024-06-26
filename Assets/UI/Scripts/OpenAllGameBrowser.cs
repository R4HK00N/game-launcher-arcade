using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenAllGameBrowser : MonoBehaviour
{
    public GameObject gameBrowser;
    public GameObject allGames;
    public GameObject firstGame;
    public NewGameDetector newGameDetector;

    public void OpenAllGames()
    {
        gameBrowser.SetActive(false);
        allGames.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstGame);
        newGameDetector.DisplayGameInfo(0);
    }
}
