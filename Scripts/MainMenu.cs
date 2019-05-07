using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{

    public GameObject muteButton;
    public GameObject unmuteButton;
    public GameObject playerObject;
    public GameObject playButton; 
    public GameObject leaderboardButton;
    public GameObject helpButton;

    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject nextButton;
    public GameObject closeButton;

    public RectTransform logo;
    public RectTransform playButtonPos;
    public RectTransform leaderboardButtonPos;
    public RectTransform muteButtonPos;
    public RectTransform helpButtonPos;

    private Vector2 textStartPosition, textEndPosition;
    private Vector2 playButtonPosition, playButtonEnd;
    private Vector2 leaderboardButtonPosition, leaderboardButtonEnd;
    private Vector2 muteButtonPosition, muteButtonEnd;
    private Vector2 helpButtonPosition, helpButtonEnd;

    public Camera menuCamera;

    public GameObject mainMenuCanvas;
    public GameObject helpCanvas;
    public GameObject player;

    public Text highScore;
    public Text coinsText;
    public Text currentLevel;


    int highestScore = 0;
    float logoSpeed = 0.5f;
    float playButtonSpeed = 1f;
    float leaderboardButtonSpeed = 1.2f;
    float startTime;
    int currentLvl;

    void Awake()
    {
        Application.targetFrameRate = 60;

    }

    public void Start()
    {
        startTime = Time.time;


        if (PlayerPrefs.HasKey("Level"))
        {
            currentLvl = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("LevelColour", 0);
        }


        // Activate the Google Play Games platform
       // PlayGamesPlatform.Activate();
         //authenticate user:
        //Social.localUser.Authenticate((bool success) =>{
        // handle success or failure
        //});

        unmuteButton = GameObject.Find("Unmute button");
        muteButton = GameObject.Find("Mute button");
        playerObject = GameObject.Find("Player");
        playButton = GameObject.Find("Play Button");
        leaderboardButton = GameObject.Find("Leaderboard Button");

        unmuteButton.SetActive(false);
        mainMenuCanvas.SetActive(true);
        helpCanvas.SetActive(false);

        logo = logo.GetComponent<RectTransform>();
        textStartPosition = logo.anchoredPosition;
        textEndPosition = new Vector2(-233.5f, 291f);

        playButtonPos = playButtonPos.GetComponent<RectTransform>();
        playButtonPosition = playButtonPos.anchoredPosition;
        playButtonEnd = new Vector2(7.2f, -163f);

        leaderboardButtonPos = leaderboardButtonPos.GetComponent<RectTransform>();
        leaderboardButtonPosition = leaderboardButtonPos.anchoredPosition;
        leaderboardButtonEnd = new Vector2(-217f, -160.1f);

        muteButtonPos = muteButtonPos.GetComponent<RectTransform>();
        muteButtonPosition = muteButtonPos.anchoredPosition;
        muteButtonEnd = new Vector2(231f, -160.1f);

        helpButtonPos = helpButtonPos.GetComponent<RectTransform>();
        helpButtonPosition = helpButtonPos.anchoredPosition;
        helpButtonEnd = new Vector2(-78f, -75f);

        highScore.canvasRenderer.SetAlpha(1.0f);

        currentLevel.canvasRenderer.SetAlpha(1.0f);

        menuCamera.enabled = true;

        highestScore = PlayerPrefs.GetInt("Score", 0);

        highScore.text = "Highest Score: " + highestScore;

        currentLevel.text = "Current Level: " + currentLvl;

    }

    public void Update()
    {
        logo.anchoredPosition = Vector2.Lerp(textStartPosition, textEndPosition, (Time.time - startTime) / logoSpeed);
        //Menu Startup Animations
        if (logo.anchoredPosition == textEndPosition)
        {
            playButtonPos.anchoredPosition = Vector2.Lerp(playButtonPosition, playButtonEnd, (Time.time - startTime) / playButtonSpeed);
            leaderboardButtonPos.anchoredPosition = Vector2.Lerp(leaderboardButtonPosition, leaderboardButtonEnd, (Time.time - startTime) / leaderboardButtonSpeed);
            muteButtonPos.anchoredPosition = Vector2.Lerp(muteButtonPosition, muteButtonEnd, (Time.time - startTime) / leaderboardButtonSpeed);
            helpButtonPos.anchoredPosition = Vector2.Lerp(helpButtonPosition, helpButtonEnd, (Time.time - startTime) / leaderboardButtonSpeed);
        }

    }

    //Open help screen 
    public void helpScreen()
    {
        helpCanvas.SetActive(true);
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        nextButton.SetActive(true);
        closeButton.SetActive(false);
    }

    //Go to next page in help screen
    public void helpScreenNext()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        nextButton.SetActive(false);
        closeButton.SetActive(true);
    }

    //Close help screen
    public void helpClose()
    {
        helpCanvas.SetActive(false);
    }

    //Load game when play button is pressed
    public void loadLevel()
    {
        StartCoroutine(playGame());
    }

    IEnumerator playGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }

    //Mute all game sound
    public void muteSound()
    {
        AudioListener.pause = true;

        AudioListener.volume = 0;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }

    //Unmute all game sound
    public void unmuteSound()
    {
        AudioListener.pause = false;

        AudioListener.volume = 1;
        unmuteButton.SetActive(false);
        muteButton.SetActive(true);
    }

    //Show leaderboard
    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

}
