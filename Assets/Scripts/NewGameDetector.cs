using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewGameDetector : MonoBehaviour
{
    [SerializeField] string gamesPath;
    public List<string> gamefolders;
    int executable = 0;
    int gameName = 1;
    int authors = 2;
    int genre = 3;
    int shortDescription = 4;
    int fullDesprictionAlinea = 4;
    [Space(20)]
    [SerializeField] int selectedGameFolder;
    int prevSelectedGameFolder = -1;
    public string selectedGameInfoExecutable;
    public string selectedGameInfoName;
    public string selectedGameInfoAuthors;
    public string selectedGameInfoGenre;
    public string selectedGameInfoshortDescription;
    public string[] selectedGameInfoFullDescription;

    private void Start()
    {
        RefreshGameLibrary();
    }

    public void Update()
    {
        if (prevSelectedGameFolder != selectedGameFolder)
        {
            prevSelectedGameFolder = selectedGameFolder;
            string[] gameInfo = GetGameInfo(selectedGameFolder);
            selectedGameInfoExecutable = gameInfo[executable];
            selectedGameInfoName = gameInfo[gameName];
            selectedGameInfoAuthors = gameInfo[authors];
            selectedGameInfoGenre = gameInfo[genre];
            selectedGameInfoshortDescription = gameInfo[shortDescription];
            selectedGameInfoFullDescription = GetFullGameDescription(gameInfo);
        }
    }

    public void RefreshGameLibrary()
    {
        gamefolders.Clear();
        foreach (string gamefolder in Directory.GetDirectories(gamesPath))
        {
            if (File.Exists(Path.Combine(gamefolder, "GAME-INFO.txt")))
            {
                string[] gameInfo = File.ReadAllLines(Path.Combine(gamefolder, "GAME-INFO.txt"));
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
}