using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using GoogleMobileAds;
using GoogleMobileAds.Api;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public Text timerText;
    public Text gameOverText;
    public Text timerScoreText;
    public Text powerupText;
    public Text highscoreText;
    public Text coinsText;
    public Text powerupScoreText;
    Vector3 input01;
    public GameObject restartButton;
    int powerupCount = 0;

    int coins = 0;

    private InterstitialAd interstitial;

    private GameObject PlayerObject;
    private BallSpawner BallSpawnerObject1;
    private BallSpawner BallSpawnerObject2;
    private BallSpawner BallSpawnerObject3;
    private BallSpawner BallSpawnerObject4;
    private BallSpawner BallSpawnerObject5;
    private BallSpawner BallSpawnerObject6;
    private BallSpawner BallSpawnerObject7;
    private BallSpawner BallSpawnerObject8;
    private BallSpawner BallSpawnerObject9;
    private BallSpawner BallSpawnerObject10;
    private BallSpawner BallSpawnerObject11;
    private BallSpawner BallSpawnerObject12;
     
    public GameObject muteButton;
    public GameObject unmuteButton;
    public GameObject mainMenuButton;
    public GameObject leaderboardButton;
    public GameObject noadsButton;
    public GameObject RBWall1;

    private BannerView bannerView;

    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody player;

    public SingleJoystick singleJoystick;
    private int count;
    public static bool gameOver;
    private float startTime;
    private int seconds;
    private bool stopTimer;

    Material material1;
    Material material2;
    Material material3;

    public GameObject mainMenuCanvas;


    int highestScore = 0;

    int skin;

    //sounds
    public AudioClip AudioSource;
    AudioSource audio;
    public float volume;

    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject nextButton;
    public GameObject closeButton;

    public GameObject helpCanvas;
    public GameObject helpButton;

    // At the start of the game..
    public void Start ()
	{

            //ads 
#if UNITY_ANDROID
        string appId = "ca-app-pub-9124426371512928~7277139236";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-9124426371512928~6407389629";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        //Start requesting for full screen ad
        this.RequestInterstitial();

        //buttons 
        unmuteButton = GameObject.Find("UnMute button");
        muteButton = GameObject.Find("Mute button");
        mainMenuButton = GameObject.Find("Menu button");
        leaderboardButton = GameObject.Find("Leaderboard Button");

        //Deactivate all buttons and canvases not needed when game starts
        unmuteButton.SetActive(false);
        muteButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noadsButton.SetActive(false);
        helpCanvas.SetActive(false);
        helpButton.SetActive(false);

        mainMenuCanvas.SetActive(true);

        RBWall1.SetActive(false);

        //sound
        audio = GetComponent<AudioSource>();

        // Assign the Rigidbody component to our private rb variable
        player = GetComponent<Rigidbody>();
       
        //Setting up a varialbe to hold the player object
        PlayerObject = GameObject.Find("Player");

        //load skins
        material1 = Resources.Load("Player") as Material;
        material2 = Resources.Load("Player 2") as Material;
        material3 = Resources.Load("Player 3") as Material;

        //-----------------------------------------------------------------------------------------------
        //Setting up the values of this object to equal the spawner objects in game
        BallSpawnerObject1 = GameObject.Find("BallSpawner1").GetComponent<BallSpawner>();
        BallSpawnerObject2 = GameObject.Find("BallSpawner2").GetComponent<BallSpawner>();
        BallSpawnerObject3 = GameObject.Find("BallSpawner3").GetComponent<BallSpawner>();
        BallSpawnerObject4 = GameObject.Find("BallSpawner4").GetComponent<BallSpawner>();
        BallSpawnerObject5 = GameObject.Find("BallSpawner5").GetComponent<BallSpawner>();
        BallSpawnerObject6 = GameObject.Find("BallSpawner6").GetComponent<BallSpawner>();
        BallSpawnerObject7 = GameObject.Find("BallSpawner7").GetComponent<BallSpawner>();
        BallSpawnerObject8 = GameObject.Find("BallSpawner8").GetComponent<BallSpawner>();
        BallSpawnerObject9 = GameObject.Find("BallSpawner9").GetComponent<BallSpawner>();
        BallSpawnerObject10 = GameObject.Find("BallSpawner10").GetComponent<BallSpawner>();
        BallSpawnerObject11 = GameObject.Find("BallSpawner11").GetComponent<BallSpawner>();
        BallSpawnerObject12 = GameObject.Find("BallSpawner12").GetComponent<BallSpawner>();

        //---------------------------------------------------------------------------------------------


        // Set the count to zero 
        count = 0;


        player.constraints = RigidbodyConstraints.FreezePositionY;

        //Set all text variables so they cannot be seen at the start
        gameOver = false;
        gameOverText.text = "";
        timerScoreText.text = "";
        powerupText.text = "";
        highscoreText.text = "";
        powerupScoreText.text = "";

        //Get start time
        startTime = Time.time;

        //Check if joystick is in scene
        if (singleJoystick == null)
        {
            Debug.LogError("A single joystick is not attached.");
        }

        //Get restart button object
        restartButton = GameObject.FindGameObjectWithTag("restartbutton");
        restartButton.SetActive(!restartButton.activeInHierarchy);

        //Request Banner Ad
        RequestBanner();

        //Hide Banner Ad
        hideBanner();
    }

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	public void OnTriggerEnter(Collider other) 
	{
		// stop freezing y axis
		if (other.gameObject.CompareTag ("Trigger"))
		{
            player.constraints = RigidbodyConstraints.None;
        }

        //Game over
        if (other.gameObject.CompareTag("gameover"))
        {
            GameOver();
        }

        //Make sure InvisWall has collisions with ONLY player
        if (other.gameObject.CompareTag("InvisWall"))
        {
            player.detectCollisions = true;
        }

        //If player collides with Rigidbody powerup
        if (other.gameObject.tag == "PickUpRB")
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(AudioSource);
            powerupCount++;
            player.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(RBBall());
        }

        //If player collides with Resize powerup
        if (other.gameObject.CompareTag("PickUpResize"))
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(ResizeBall());
        }

        //If player collides with Spawncount powerup
        if (other.gameObject.CompareTag("PickUpSpawnCount"))
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(SpawnCountBall());

        }

        //If player collides with Resize powerup
        if (other.gameObject.CompareTag("PickUpResizeLarger"))
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(AudioSource);
            StartCoroutine(ResizeBallLarger());
        }

        //If player collides with Movement powerup
        if (other.gameObject.CompareTag("PickUpChangeMovementSpeed"))
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(AudioSource);
            StartCoroutine(ChangeMovmentTemp());
        }
    }
    
    //Resize powerup
    IEnumerator ResizeBall()
    {
        powerupText.text = "BALL SIZE REDUCED!";
        PlayerObject.gameObject.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
        yield return new WaitForSeconds(5);
        powerupText.text = "";
        PlayerObject.gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
    }

    //Resize larger powerup
    IEnumerator ResizeBallLarger()
    {
        powerupText.text = "BALL SIZE MADE LARGER!";
        PlayerObject.gameObject.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(5);
        powerupText.text = "";
        PlayerObject.gameObject.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
    }

    //Movement powerup
    IEnumerator ChangeMovmentTemp()
    {
        powerupText.text = "MOVEMENT HAS BEEN SLOWED!";
        speed = 1;
        yield return new WaitForSeconds(3);
        powerupText.text = "";
        speed = 10;
    }

    //Rigidbody powerup
    IEnumerator RBBall()
    {
        powerupText.text = "BALL HAS NO COLLISION!";
        gameObject.layer = 10;
        player.constraints = RigidbodyConstraints.FreezePositionY;
        RBWall1.SetActive(true);
        yield return new WaitForSeconds(5);
        powerupText.text = "";
        gameObject.layer = 9;
        RBWall1.SetActive(false);
    }

    //Spawncount powerup
    IEnumerator SpawnCountBall()
    {
        powerupText.text = "SPAWN COUNT REDUCED!";
        BallSpawnerObject1.hazardCount = 1;
        BallSpawnerObject2.hazardCount = 1;
        BallSpawnerObject3.hazardCount = 1;
        BallSpawnerObject4.hazardCount = 1;
        BallSpawnerObject5.hazardCount = 1;
        BallSpawnerObject6.hazardCount = 1;
        BallSpawnerObject7.hazardCount = 1;
        BallSpawnerObject8.hazardCount = 1;
        BallSpawnerObject9.hazardCount = 1;
        BallSpawnerObject10.hazardCount = 1;
        BallSpawnerObject11.hazardCount = 1;
        BallSpawnerObject12.hazardCount = 1;
        yield return new WaitForSeconds(6);
        powerupText.text = "";
        BallSpawnerObject1.hazardCount = 10;
        BallSpawnerObject2.hazardCount = 10;
        BallSpawnerObject3.hazardCount = 10;
        BallSpawnerObject4.hazardCount = 10;
        BallSpawnerObject5.hazardCount = 10;
        BallSpawnerObject6.hazardCount = 10;
        BallSpawnerObject7.hazardCount = 10;
        BallSpawnerObject8.hazardCount = 10;
        BallSpawnerObject9.hazardCount = 10;
        BallSpawnerObject10.hazardCount = 10;
        BallSpawnerObject11.hazardCount = 10;
        BallSpawnerObject12.hazardCount = 10;

    }

    //Delay function
    IEnumerator Wait()
    {  
        yield return new WaitForSeconds(0.5f);
        gameOver = true; 
        Time.timeScale = 0;
    }

    void Update()
    {
        // get input from both joysticks
        input01 = singleJoystick.GetInputDirection();

        float xMovementInput01 = input01.x; // The horizontal movement from joystick 01
        float zMovementInput01 = input01.y; // The vertical movement from joystick 01	

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3(input01.x, 0, input01.y);

        // Add a physical force to our Player rigidbody using movement * speed
        player.AddForce(movement * speed);

        //Clear timer when game ends
        if (stopTimer == true)
        {
            timerText.text = "";
        }
        else
        {
            float t = Time.time - startTime;

            seconds = Mathf.RoundToInt(t);

            timerText.text = "SCORE:" + seconds;
        }
        
    }

    //Game over code that runs when player hits game over trigger
    public void GameOver()
    {
        //Get player's highest saved score
        int highscore = PlayerPrefs.GetInt("Score");

        //Clear timer
        timerText.text = "";
  
        //Create game over text
        gameOverText.text = "GAME OVER!";

        //Give extra score if player got powerups
        seconds = seconds + (powerupCount * 5);

        //Tell the player how many powerups they got
        if (powerupCount == 1)
        {
            powerupScoreText.text = "You got " + powerupCount + " powerup! +" + (powerupCount * 5) + " score";
        }
        else if(powerupCount > 0)
        {
            powerupScoreText.text = "You got " + powerupCount + " powerups! +" + (powerupCount * 5) + " score";
        }
        else
        {
            powerupScoreText.text = "Hint: Getting Powerups gives you more score!";
        }
        //Show players score
        timerScoreText.text = "YOUR SCORE:" + seconds;

        //Show players highest score
        highscoreText.text = "HIGHEST SCORE:" + highscore;
        powerupText.text = "";

        //Stop timer
        stopTimer = true;

        //If player score is over players highest score, overwrite and save as new highscore
        if (seconds > highscore)
        {
            PlayerPrefs.SetInt("Score", seconds);
        }

        //Reset score 
        seconds = 0;

        //Show fullscreen ad
        this.ShowInterstitial();
        //Delay so player does not miss out on anything while watching ad 
        StartCoroutine(Wait());

        //Setup mute and unmute buttons
        if(AudioListener.pause == true)
        {
            unmuteButton.SetActive(true);
        }
        else if(AudioListener.pause == false){
            muteButton.SetActive(true);
        }

        //Show menu buttons
        restartButton.SetActive(true);
        leaderboardButton.SetActive(true);
        helpButton.SetActive(true);

        //Show banner ad
        showBanner();
    }

    public void helpScreen()
    {
        helpCanvas.SetActive(true);
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        nextButton.SetActive(true);
        closeButton.SetActive(false);
    }

    public void helpScreenNext()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        nextButton.SetActive(false);
        closeButton.SetActive(true);
    }

    public void helpClose()
    {
        helpCanvas.SetActive(false);
    }

    private void hideBanner()
    {
        bannerView.Hide();
    }

    private void showBanner()
    {
        bannerView.Show();
    }

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

    //Restart game code
    public void restart()
    {
        hideBanner();

        //Reload game scene
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;

    }

    //Show leaderboard UI
    public void showLeaderboard()
    {
        int highscore = PlayerPrefs.GetInt("Score");
        Social.ReportScore(highscore, "CgkItaqpobAHEAIQAg", (bool success) => {

        });
        Social.ShowLeaderboardUI();
    }

    public void muteSound()
    {
        AudioListener.pause = true;

        AudioListener.volume = 0;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }

    public void unmuteSound()
    {
        AudioListener.pause = false;

        AudioListener.volume = 1;
        unmuteButton.SetActive(false);
        muteButton.SetActive(true);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }


    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-9124426371512928/7085567547"; //ca-app-pub-9124426371512928/7085567547
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9124426371512928/3023033605"; //ca-app-pub-9124426371512928/3023033605
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
       
        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }
    private void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .Build();
    }


}