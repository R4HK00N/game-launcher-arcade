using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class NewGameDetector : MonoBehaviour
{
    [SerializeField] string gamesPath;
    public List<string> gamefolders;
    public List<Texture2D> gamecovers;
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
    [SerializeField] List<Image> coverImages;
    //debugging
    //
    //[Space(20)]
    //public Image coverImage;
    //public TextMeshProUGUI nameDisplay;
    //public TextMeshProUGUI authorDisplay;
    //public TextMeshProUGUI genreDisplay;

    private void Start()
    {
        RefreshGameLibrary();
        DisplayGameInfo();
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

        DisplayGameInfo();
    }

    void DisplayGameInfo()
    {
        string[] gameInfo = GetGameInfo(selectedGameFolder);
        selectedGameInfoExecutable = gameInfo[executable];
        selectedGameInfoName = gameInfo[gameName];
        selectedGameInfoAuthors = gameInfo[authors];
        selectedGameInfoGenre = gameInfo[genre];
        selectedGameInfoshortDescription = gameInfo[shortDescription];
        selectedGameInfoFullDescription = GetFullGameDescription(gameInfo);

        for (int j = 0; j < coverImages.Count - 1; j++)
        {
            Texture2D spriteTexture = gamecovers[selectedGameFolder + j];
            coverImages[j].sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
        }

        //testscene display
        //
        //Texture2D spriteTexture = gamecovers[selectedGameFolder];
        //
        //coverImage.sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
        //nameDisplay.text = selectedGameInfoName;
        //authorDisplay.text = selectedGameInfoAuthors;
        //genreDisplay.text = selectedGameInfoGenre;
    }

    public void PlaySelectedGame()
    {
        string gamePath = Path.Combine(gamefolders[selectedGameFolder], selectedGameInfoExecutable);

        Process.Start(gamePath);
    }
}