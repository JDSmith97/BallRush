using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GoogleMobileAds.Api;

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

    private BannerView bannerView;

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

    public Camera camera;

    public GameObject mainMenuCanvas;
    public GameObject helpCanvas;
    public GameObject player;

    public Text highScore;
    public Text coinsText;

    Material material1;
    Material material2;
    Material material3;

    int[] objects = { 1, 2, 3 };
    int objectPos = 0;
    int highestScore = 0;
    int skin = 0;
    int coins = 0;
    float logoSpeed = 0.5f;
    float playButtonSpeed = 1f;
    float leaderboardButtonSpeed = 1.2f;
    float startTime;
    bool logoEnd = false;


    public void Start()
    {
        //Google Ads AppID's
#if UNITY_ANDROID
        string appId = "ca-app-pub-9124426371512928/6510852473";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-9124426371512928/9915745016";
#else
        string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        // authenticate user:
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
        });

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
        textEndPosition = new Vector2(-233.5f, 259.68f);

        playButtonPos = playButtonPos.GetComponent<RectTransform>();
        playButtonPosition = playButtonPos.anchoredPosition;
        playButtonEnd = new Vector2(7.2f, -146.8f);

        leaderboardButtonPos = leaderboardButtonPos.GetComponent<RectTransform>();
        leaderboardButtonPosition = leaderboardButtonPos.anchoredPosition;
        leaderboardButtonEnd = new Vector2(-217f, -160.1f);

        muteButtonPos = muteButtonPos.GetComponent<RectTransform>();
        muteButtonPosition = muteButtonPos.anchoredPosition;
        muteButtonEnd = new Vector2(231f, -160.1f);

        helpButtonPos = helpButtonPos.GetComponent<RectTransform>();
        helpButtonPosition = helpButtonPos.anchoredPosition;
        helpButtonEnd = new Vector2(562f, 250f);

        highScore.canvasRenderer.SetAlpha(0.0f);

        startTime = Time.time;

        camera.enabled = true;

        material1 = Resources.Load("Player") as Material;

        highestScore = PlayerPrefs.GetInt("Score", 0);
        objectPos = PlayerPrefs.GetInt("Skin", 0);

        highScore.text = "HIGHEST SCORE:" + highestScore;

        //Request Banner Ad
        RequestBanner();

    }

    public void FixedUpdate()
    {
        logo.anchoredPosition = Vector2.Lerp(textStartPosition, textEndPosition, (Time.time - startTime) / logoSpeed);
        //Menu Startup Animations
        if (logo.anchoredPosition == textEndPosition)
        {
            logoEnd = true;
            highScore.CrossFadeAlpha(1.0f, 1.5f, false);
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
    public void loadScene()
    {
        hideBanner();
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

    //Hide Banner Ad
    public void hideBanner()
    {
        bannerView.Hide();
    }

    //Request Banner using Google Ad's request code
    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9124426371512928/6510852473";  //ca-app-pub-9124426371512928/6510852473
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-9124426371512928/9915745016"; //ca-app-pub-9124426371512928/9915745016
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.

        this.bannerView.LoadAd(request);

    }
        
}
