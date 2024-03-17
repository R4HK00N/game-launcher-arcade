using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class NewGameDetector : MonoBehaviour
{
    [SerializeField] string gamesPath;
    public List<string> gamefolders;
    public List<Texture2D> gamecovers;
    public List<Texture2D> gamebanners;
    int executable = 0;
    int gameName = 1;
    int authors = 2;
    int genre = 3;
    int shortDescription = 4;
    int fullDesprictionAlinea = 4;
    [Space(20)]
    [SerializeField] int selectedGameFolder;
    public string selectedGameInfoExecutable;
    public string selectedGameInfoName;
    public string selectedGameInfoAuthors;
    public string selectedGameInfoGenre;
    public string selectedGameInfoshortDescription;
    public string[] selectedGameInfoFullDescription;
    [Space(20)]
    [SerializeField] GameObject gamebrowser;
    [SerializeField] GameObject gamedetails;
    [Space(20)]
    [Header("Browser")]
    [SerializeField] Image highLightedGameCover;
    [SerializeField] List<Image> coverImages;
    [Space(20)]
    [Header("Details")]
    public Image bannerImage;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI authorDisplay;
    public TextMeshProUGUI descriptionDisplay;
    //public TextMeshProUGUI genreDisplay;

    private void Start()
    {
        RefreshGameLibrary();
        DisplayGameInfo(0);
    }

    public void RefreshGameLibrary()
    {
        gamefolders.Clear();
        foreach (string gamefolder in Directory.GetDirectories(gamesPath))
        {
            if (File.Exists(Path.Combine(gamefolder, "GAME-INFO.txt")))
            {
                string[] gameInfo = File.ReadAllLines(Path.Combine(gamefolder, "GAME-INFO.txt"));
                if (File.Exists(Path.Combine(gamefolder, "cover.png")))
                {
                    string path = Path.Combine(gamefolder, "cover.png");
                    byte[] bytes = File.ReadAllBytes(path);

                    Texture2D loadTexture = new Texture2D(1, 1);
                    loadTexture.LoadImage(bytes);

                    gamecovers.Add(loadTexture);
                }
                if (File.Exists(Path.Combine(gamefolder, "banner.png")))
                {
                    string path = Path.Combine(gamefolder, "banner.png");
                    byte[] bytes = File.ReadAllBytes(path);

                    Texture2D loadTexture = new Texture2D(1, 1);
                    loadTexture.LoadImage(bytes);

                    gamebanners.Add(loadTexture);
                }
                gamefolders.Add(gamefolder);
            }
        }
    }

    public string[] GetGameInfo(int requestedInfo)
    {
        return File.ReadAllLines(Path.Combine(gamefolders[requestedInfo], "GAME-INFO.txt"));
    }

    public string[] GetFullGameDescription(string[] gameInfo)
    {
        string[] response = new string[gameInfo.Length - fullDesprictionAlinea + 1];
        for (int i = 0; i < response.Length - 1; i++)
        {
            response[i] = gameInfo[i + 4];
        }
        return response;
    }

    public void SwitchGame(bool skipForward)
    {
        if (skipForward)
        {
            if (selectedGameFolder < gamefolders.Count - 1)
            {
                selectedGameFolder++;
            }
            else
            {
                selectedGameFolder = 0;
            }
        }
        else if (!skipForward)
        {
            if (selectedGameFolder > 0)
            {
                selectedGameFolder--;
            }
            else
            {
                selectedGameFolder = gamefolders.Count - 1;
            }
        }

        DisplayGameInfo(0);
    }

    public void DisplayGameInfo(int index)
    {
        selectedGameFolder = index;

        string[] gameInfo = GetGameInfo(selectedGameFolder);
        selectedGameInfoExecutable = gameInfo[executable];
        selectedGameInfoName = gameInfo[gameName];
        selectedGameInfoAuthors = gameInfo[authors];
        selectedGameInfoGenre = gameInfo[genre];
        selectedGameInfoshortDescription = gameInfo[shortDescription];
        selectedGameInfoFullDescription = GetFullGameDescription(gameInfo);

        //gamebrowser
        if (gamebrowser.activeSelf)
        {
            Texture2D spriteTextureOfHighlight = gamecovers[selectedGameFolder];
            highLightedGameCover.sprite = Sprite.Create(spriteTextureOfHighlight, new Rect(0, 0, spriteTextureOfHighlight.width, spriteTextureOfHighlight.height), new Vector2(0, 0));

            for (int j = 0; j < coverImages.Count - 1; j++)
            {
                if (j > gamefolders.Count - 1)
                {
                    return;
                }    
                Texture2D spriteTexture = gamecovers[selectedGameFolder + j];
                coverImages[j].sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
                coverImages[j].gameObject.GetComponent<ButtonInfo>().SetIndex(j);
            }
        }
        else if (gamedetails.activeSelf)
        {
            Texture2D spriteTexture = gamebanners[selectedGameFolder];

            bannerImage.sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
            nameDisplay.text = selectedGameInfoName;
            authorDisplay.text = selectedGameInfoAuthors;
            descriptionDisplay.text = ""; //clear all text
            for (int l = 0; l < selectedGameInfoFullDescription.Length - 1; l++)
            {
                if (l == 0)
                {
                    descriptionDisplay.text = selectedGameInfoFullDescription[l];
                }
                else
                {
                    descriptionDisplay.text += $"<br>{selectedGameInfoFullDescription[l]}";
                }
            }
            //genreDisplay.text = selectedGameInfoGenre;
        }
    }

    public void PlaySelectedGame()
    {
        string gamePath = Path.Combine(gamefolders[selectedGameFolder], selectedGameInfoExecutable);

        Process.Start(gamePath);
    }
}