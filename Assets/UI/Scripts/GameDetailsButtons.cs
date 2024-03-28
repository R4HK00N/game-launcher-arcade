using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameDetailsButtons : MonoBehaviour
{
    public Animator animator;
    public GameObject gameBrowser;
    public GameObject gameDetails;
    public GameObject playButton;
    public GameObject highlightButton;
    public UpAndDownAnimation upAndDownAnimation;
    public NewGameDetector newGameDetector;
    public bool goBackToBrowser;

    public void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == playButton)
        {
            animator.SetTrigger("ScrollUp");
            upAndDownAnimation.CanScrollDown();
            upAndDownAnimation.scrolledDown = false;
        }
    }
    public void GameClick()
    {
        gameDetails.SetActive(true);
        highlightButton.GetComponent<ButtenSizer>().DeselectButton();
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
            upAndDownAnimation.CanNotScrollDown();
            //SceneManager.LoadScene(1);
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
