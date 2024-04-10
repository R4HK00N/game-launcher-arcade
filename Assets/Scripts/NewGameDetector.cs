using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using QRCodeGenerator23;
using ZXing;
using ZXing.QrCode;
using UnityEngine.EventSystems;

public class NewGameDetector : MonoBehaviour
{
    [SerializeField] string gamesPath;
    public List<string> gamefolders;
    public List<Texture2D> gamecovers;
    public List<Texture2D> gamebanners;
    int executable = 0;
    int gameName = 1;
    int gameLink = 2;
    int authors = 3;
    int genre = 4;
    int shortDescription = 5;
    int fullDesprictionAlinea = 5;
    [Space(20)]
    public int selectedGameFolder;
    public string selectedGameInfoExecutable;
    public string selectedGameInfoName;
    public string selectedGameInfoLink;
    public string selectedGameInfoAuthors;
    public string selectedGameInfoGenre;
    public string selectedGameInfoshortDescription;
    public string[] selectedGameInfoFullDescription;
    public List<Texture2D> selectedGameExtraImages;
    [Space(20)]
    [SerializeField] GameObject gamebrowser;
    [SerializeField] GameObject gamedetails;
    [Space(20)]
    [Header("Browser")]
    [SerializeField] Image highLightedGameCover;
    [SerializeField] List<Image> coverImages;
    [SerializeField] Texture2D emptyGameSlotImage;
    [Space(20)]
    [Header("Details")]
    public Sprite extraImagePlaceHolder;
    public Image bannerImage;
    public Image qrImage;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI authorDisplay;
    public TextMeshProUGUI descriptionDisplay;
    public GameObject extraImageGameObject;
    public List<GameObject> spawnedExtraImageGameObjects;
    public static Texture2D encoded;
    //public TextMeshProUGUI genreDisplay;

    private void Start()
    {
        RefreshGameLibrary();
        DisplayGameInfo(0);

        string gamePath = Path.Combine(gamesPath, "KeyMapper.exe");

        Process.Start(gamePath);
    }

    public void OnScrollRight()
    {
        if (EventSystem.current.currentSelectedGameObject.TryGetComponent<ButtonInfo>(out ButtonInfo _buttonInfo))
        {
            if (_buttonInfo.GetIndex() == 2 || _buttonInfo.GetIndex() == 5)
            {
                LoadNextLibraryWindow(_buttonInfo, true);
            }
        }
    }

    public void OnScrollLeft()
    {
        if (EventSystem.current.currentSelectedGameObject.TryGetComponent<ButtonInfo>(out ButtonInfo _buttonInfo))
        {
            if (_buttonInfo.GetIndex() == 0)
            {
                LoadNextLibraryWindow(_buttonInfo , false);
            }
        }
    }

    public void Update()
    {
        UnityEngine.Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        if (EventSystem.current.currentSelectedGameObject.TryGetComponent<ButtonInfo>(out ButtonInfo _buttonInfo))
        {
            selectedGameFolder = _buttonInfo.GetIndex();
        }
        
        string[] gameInfo = GetGameInfoByInt(selectedGameFolder);
        selectedGameInfoExecutable = gameInfo[executable];
        selectedGameInfoName = gameInfo[gameName];
        selectedGameInfoLink = gameInfo[gameLink];
        selectedGameInfoAuthors = gameInfo[authors];
        selectedGameInfoGenre = gameInfo[genre];
        selectedGameInfoshortDescription = gameInfo[shortDescription];
        selectedGameInfoFullDescription = GetFullGameDescription(gameInfo);
    }

    public void RefreshGameLibrary()
    {
        gamefolders.Clear();
        foreach (string gamefolder in Directory.GetDirectories(gamesPath))
        {
            if (IsValidGameFolder(gamefolder))
            {
                string[] gameInfo = File.ReadAllLines(Path.Combine(gamefolder, "GAME-INFO.txt"));

                string coverPath = Path.Combine(gamefolder, "cover.png");
                byte[] coverBytes = File.ReadAllBytes(coverPath);

                Texture2D loadCoverTexture = new Texture2D(1, 1);
                loadCoverTexture.LoadImage(coverBytes);

                gamecovers.Add(loadCoverTexture);


                string bannerPath = Path.Combine(gamefolder, "banner.png");
                byte[] bannerBytes = File.ReadAllBytes(bannerPath);

                Texture2D loadBannerTexture = new Texture2D(1, 1);
                loadBannerTexture.LoadImage(bannerBytes);

                gamebanners.Add(loadBannerTexture);

                gamefolders.Add(gamefolder);
            }
        }
    }

    public bool IsValidGameFolder(string gamefolder)
    {
        bool valid = false;
        if (File.Exists(Path.Combine(gamefolder, "GAME-INFO.txt")) && File.Exists(Path.Combine(gamefolder, "cover.png")) && File.Exists(Path.Combine(gamefolder, "banner.png")))
        {
            string[] gameInfo = GetGameInfoByString(gamefolder);
            if (File.Exists(Path.Combine(gamefolder, gameInfo[executable])))
            {
                valid = true;
            }
        }
        return valid;
    }

    public string[] GetGameInfoByInt(int requestedInfo)
    {
        return File.ReadAllLines(Path.Combine(gamefolders[requestedInfo], "GAME-INFO.txt"));
    }

    public string[] GetGameInfoByString(string folderPath)
    {
        return File.ReadAllLines(Path.Combine(folderPath, "GAME-INFO.txt"));
    }

    public string[] GetFullGameDescription(string[] gameInfo)
    {
        string[] response = new string[gameInfo.Length - fullDesprictionAlinea + 1];
        for (int i = 0; i < response.Length - 1; i++)
        {
            response[i] = gameInfo[i + shortDescription];
        }
        return response;
    }

    //This function is for a debugging scene
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
    //    selectedGameFolder = index;

        //gamebrowser
        if (gamebrowser.activeSelf)
        {
            Texture2D spriteTextureOfHighlight = gamecovers[selectedGameFolder];
            highLightedGameCover.sprite = Sprite.Create(spriteTextureOfHighlight, new Rect(0, 0, spriteTextureOfHighlight.width, spriteTextureOfHighlight.height), new Vector2(0, 0));

            for (int j = 0; j < coverImages.Count; j++)
            {
                if (index + j > gamefolders.Count - 1)
                {
                    coverImages[j].sprite = Sprite.Create(emptyGameSlotImage, new Rect(0, 0, emptyGameSlotImage.width, emptyGameSlotImage.height), new Vector2(0, 0));
                    coverImages[j].gameObject.GetComponent<ButtonInfo>().SetIndex(-1);
                }
                else
                {
                    Texture2D spriteTexture = gamecovers[selectedGameFolder + j];
                    coverImages[j].sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
                    coverImages[j].gameObject.GetComponent<ButtonInfo>().SetIndex(j);
                }
            }
        }
        else if (gamedetails.activeSelf)
        {
            Texture2D spriteTexture = gamebanners[selectedGameFolder];

            bannerImage.sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0));
            if (selectedGameInfoLink != "")
            {
                GenerateQROutput(selectedGameInfoLink);
            }
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
            //Load other images in the folder
            bool lastOneFound = false;
            selectedGameExtraImages.Clear();
            for (int i = 1; !lastOneFound; i++)
            {
                if (File.Exists(Path.Combine(gamefolders[selectedGameFolder], $"image{i}.png")))
                {
                    byte[] bytes = File.ReadAllBytes(Path.Combine(gamefolders[selectedGameFolder], $"image{i}.png"));

                    Texture2D loadTexture = new Texture2D(1, 1);
                    loadTexture.LoadImage(bytes);

                    selectedGameExtraImages.Add(loadTexture);
                }
                else
                {
                    lastOneFound = true;
                }
            }
            for (int i = 0; i < selectedGameExtraImages.Count; i++)
            {
                if (i == 0)
                {
                    extraImageGameObject.GetComponent<Image>().overrideSprite = Sprite.Create(selectedGameExtraImages[i], new Rect(0, 0, selectedGameExtraImages[i].width, selectedGameExtraImages[i].height), new Vector2(0, 0));
                }
                else
                {
                    GameObject newImageDisplay = Instantiate(extraImageGameObject, extraImageGameObject.transform.position, Quaternion.identity);
                    newImageDisplay.transform.SetParent(extraImageGameObject.transform.parent);
                    newImageDisplay.GetComponent<Image>().sprite = Sprite.Create(selectedGameExtraImages[i], new Rect(0, 0, selectedGameExtraImages[i].width, selectedGameExtraImages[i].height), new Vector2(0, 0));
                    spawnedExtraImageGameObjects.Add(newImageDisplay);
                }
            }
            //genreDisplay.text = selectedGameInfoGenre;
        }
    }

    public void LoadNextLibraryWindow(ButtonInfo _button, bool _next)
    {
        if (_next)
        {
            int windowIndex = _button.GetIndexInWindow(_button.GetIndex());
            windowIndex += 1;
            windowIndex *= gamecovers.Count;
            windowIndex -= 1;
            UnityEngine.Debug.Log(windowIndex);
            selectedGameFolder = windowIndex;
            DisplayGameInfo(windowIndex);
        }
        else
        {
            int windowIndex = _button.GetIndexInWindow(_button.GetIndex());
            UnityEngine.Debug.Log(windowIndex);
            //windowIndex -= 1;
            //windowIndex *= gamecovers.Count;
            //windowIndex -= 1;
            if (windowIndex > -1)
            {
                DisplayGameInfo(windowIndex);
            }
        }
    }

    public void PlaySelectedGame()
    {
        string gamePath = Path.Combine(gamefolders[selectedGameFolder], selectedGameInfoExecutable);

        Process.Start(gamePath);
    }

    // For generating the QRCode Image
    public void GenerateQROutput(string link)
    {
        encoded = new Texture2D(312, 312);
        var textForEncoding = link;
        if (textForEncoding != null)
        {
            var color32 = Encode(textForEncoding, encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
        }

        qrImage.sprite = Sprite.Create(encoded, new Rect(0, 0, encoded.width, encoded.height), Vector2.zero);
    }

    // For generating QRCode
    public static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public void ResetExtraImages()
    {
        Image defaultImage = extraImageGameObject.GetComponent<Image>();
        defaultImage.overrideSprite = extraImagePlaceHolder;

        foreach (GameObject spawnedImageHolder in spawnedExtraImageGameObjects)
        {
            spawnedExtraImageGameObjects.Remove(spawnedImageHolder);
            Destroy(spawnedImageHolder);
        }
    }
}