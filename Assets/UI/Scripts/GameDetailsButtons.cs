using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameDetailsButtons : MonoBehaviour
{
    public Animator animator;
    public GameObject gameBrowser;
    public GameObject gameDetails;
    public GameObject playButton;
    public NewGameDetector newGameDetector;
    public bool goBackToBrowser;

    public void GameClick()
    {
        animator.SetTrigger("ScrollUp");
        gameDetails.SetActive(true);
        gameBrowser.SetActive(false);
        newGameDetector.DisplayGameInfo(EventSystem.current.currentSelectedGameObject.GetComponent<ButtonInfo>().GetIndex());
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    public void OnGoBack()
    {
        newGameDetector.ResetExtraImages();

        if (goBackToBrowser)
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
