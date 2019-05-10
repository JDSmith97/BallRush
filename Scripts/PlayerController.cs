using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using Ez.Pooly;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

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
    int pastScore;
    int powerupScore;

    private GameObject PlayerObject;

    public bool completeLvl = false;

    private PoolySpawner spawner1;
    private PoolySpawner spawner2;
    private PoolySpawner spawner3;
    private PoolySpawner spawner4;
    private PoolySpawner spawner5;
    private PoolySpawner spawner6;
    private PoolySpawner spawner7;
    private PoolySpawner spawner8;
    private PoolySpawner spawner9;
    private PoolySpawner spawner10;
    private PoolySpawner spawner11;
    private PoolySpawner spawner12;
    private PoolySpawner spawner13;
    private PoolySpawner spawnerBig1;
    private PoolySpawner spawnerBig2;
    private PoolySpawner spawnerBig3;
    private PoolySpawner spawnerPowerupRB;
    private PoolySpawner spawnerPowerupResize;
    private PoolySpawner spawnerPowerupSpawnCount;
    private PoolySpawner spawnerPowerupResizeLarger;
    private PoolySpawner spawnerPowerupMovement;

    public GameObject muteButton;
    public GameObject unmuteButton;
    public GameObject gameoverMuteButton;
    public GameObject gameoverUnmuteButton;
    public GameObject mainMenuButton;
    public GameObject leaderboardButton;
    public GameObject noadsButton;
    public GameObject nextLevelButton;

    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody player;

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
    AudioSource gameAudio;
    public AudioClip song;
    AudioSource theSong;
    
    public float volume;

    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject nextButton;
    public GameObject closeButton;

    public GameObject helpCanvas;
    public GameObject helpButton;

    public int totalScore;
    public int currentScore = 0;
    public Slider progressBar;

    public Text currentLvlText;
    public Text nextLvlText;
    private int currentLvl = 1;
    private int nextLvl = 2;
    private bool firstTime;
    public static bool levelComplete = false;

    public GameObject spawnerGameObject1;
    public GameObject spawnerGameObject2;
    public GameObject spawnerGameObject3;
    public GameObject spawnerGameObject4;
    public GameObject spawnerGameObject5;
    public GameObject spawnerGameObject6;
    public GameObject spawnerGameObject7;
    public GameObject spawnerGameObject8;
    public GameObject spawnerGameObject9;
    public GameObject spawnerGameObject10;
    public GameObject spawnerGameObject11;
    public GameObject spawnerGameObject12;
    public GameObject spawnerGameObject13;
    public GameObject spawnerRB;
    public GameObject spawnerResize;
    public GameObject spawnerSpawnCount;
    public GameObject spawnerResizeLarger;
    public GameObject spawnerMovement;
    public GameObject spawnerBigBall1;
    public GameObject spawnerBigBall2;
    public GameObject spawnerBigBall3;

    private float minValue;
    private float maxValue;

    public int[] colours = { 1, 2, 3, 4, 5 };
    public int arrayPos = 0;

    public Material[] material;
    public MeshRenderer meshRenderer;

    bool onetime = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // At the start of the game..
    public void Start ()
	{
        Time.timeScale = 1;

        //buttons 
        unmuteButton = GameObject.Find("UnMute button");
        muteButton = GameObject.Find("Mute button");
        mainMenuButton = GameObject.Find("Menu button");
        leaderboardButton = GameObject.Find("Leaderboard Button");

        //Deactivate all buttons and canvases not needed when game starts
        unmuteButton.SetActive(false);
        muteButton.SetActive(false);
        gameoverUnmuteButton.SetActive(false);
        gameoverMuteButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noadsButton.SetActive(false);
        helpCanvas.SetActive(false);
        helpButton.SetActive(false);
        nextLevelButton.SetActive(false);

        mainMenuCanvas.SetActive(true);

        //sound
        gameAudio = GetComponent<AudioSource>();

        theSong = GetComponent<AudioSource>();

        // Assign the Rigidbody component to our private rb variable
        player = GetComponent<Rigidbody>();
       
        //Setting up a varialbe to hold the player object
        PlayerObject = GameObject.Find("Player");

        //---------------------------------------------------------------------------------------------
        //Setting up spawners
        spawner1 = spawnerGameObject1.GetComponent<PoolySpawner>();
        spawner2 = spawnerGameObject2.GetComponent<PoolySpawner>();
        spawner3 = spawnerGameObject3.GetComponent<PoolySpawner>();
        spawner4 = spawnerGameObject4.GetComponent<PoolySpawner>();
        spawner5 = spawnerGameObject5.GetComponent<PoolySpawner>();
        spawner6 = spawnerGameObject6.GetComponent<PoolySpawner>();
        spawner7 = spawnerGameObject7.GetComponent<PoolySpawner>();
        spawner8 = spawnerGameObject8.GetComponent<PoolySpawner>();
        spawner9 = spawnerGameObject9.GetComponent<PoolySpawner>();
        spawner10 = spawnerGameObject10.GetComponent<PoolySpawner>();
        spawner11 = spawnerGameObject11.GetComponent<PoolySpawner>();
        spawner12 = spawnerGameObject12.GetComponent<PoolySpawner>();
        spawner13 = spawnerGameObject13.GetComponent<PoolySpawner>();
        spawnerPowerupResize = spawnerResize.GetComponent<PoolySpawner>();
        spawnerPowerupSpawnCount = spawnerSpawnCount.GetComponent<PoolySpawner>();
        spawnerPowerupResizeLarger = spawnerResizeLarger.GetComponent<PoolySpawner>();
        spawnerBig1 = spawnerBigBall1.GetComponent<PoolySpawner>();
        spawnerBig2 = spawnerBigBall2.GetComponent<PoolySpawner>();
        spawnerBig3 = spawnerBigBall3.GetComponent<PoolySpawner>();
        //---------------------------------------------------------------------------------------------

        // Set the count to zero 

        count = 0;

        pastScore = PlayerPrefs.GetInt("PastScore");

        //Get Music
        theSong.clip = song;

        player.constraints = RigidbodyConstraints.FreezePositionY;

        //Set all text variables so they cannot be seen at the start
        gameOver = false;
        levelComplete = false;
        gameOverText.text = "";
        timerScoreText.text = "";
        powerupText.text = "";
        highscoreText.text = "";
        powerupScoreText.text = "";

        currentLvlText.text = "" + currentLvl;
        nextLvlText.text = "" + nextLvl;

        //Get start time
        startTime = Time.time;

        //Get restart button object
        restartButton = GameObject.FindGameObjectWithTag("restartbutton");
        restartButton.SetActive(!restartButton.activeInHierarchy);


        if (PlayerPrefs.HasKey("Level"))
        {
            currentLvl = PlayerPrefs.GetInt("Level");
            arrayPos = PlayerPrefs.GetInt("LevelColour");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            arrayPos = 0;
            PlayerPrefs.SetInt("LevelColour", 0);
        }

        
        currentLvlText.text = "" + currentLvl;
        nextLvl = currentLvl+1;
        nextLvlText.text = "" + nextLvl;

        spawner1.ResumeSpawn();
        spawner2.ResumeSpawn();
        spawner3.ResumeSpawn();
        spawner4.ResumeSpawn();
        spawner5.ResumeSpawn();
        spawner6.ResumeSpawn();
        spawner7.ResumeSpawn();
        spawner8.ResumeSpawn();
        spawner9.ResumeSpawn();
        spawner10.ResumeSpawn();
        spawner11.ResumeSpawn();
        spawner12.ResumeSpawn();
        spawnerPowerupResize.ResumeSpawn();
        spawnerPowerupSpawnCount.ResumeSpawn();
        spawnerPowerupResizeLarger.ResumeSpawn();
        spawnerBig1.ResumeSpawn();
        spawnerBig2.ResumeSpawn();
        spawnerBig3.ResumeSpawn();

       if (currentLvl > 0 && currentLvl < 7) {
            spawner1.spawnAtRandomIntervalMinimum = 1;
            spawner1.spawnAtRandomIntervalMaximum = 3.5f;

            spawner2.spawnAtRandomIntervalMinimum = 1;
            spawner2.spawnAtRandomIntervalMaximum = 3.5f;

            spawner3.spawnAtRandomIntervalMinimum = 1;
            spawner3.spawnAtRandomIntervalMaximum = 3.5f;

            spawner4.spawnAtRandomIntervalMinimum = 1;
            spawner4.spawnAtRandomIntervalMaximum = 3.5f;

            spawner5.spawnAtRandomIntervalMinimum = 1;
            spawner5.spawnAtRandomIntervalMaximum = 3.5f;

            spawner6.spawnAtRandomIntervalMinimum = 1;
            spawner6.spawnAtRandomIntervalMaximum = 3.5f;

            spawner7.spawnAtRandomIntervalMinimum = 1;
            spawner7.spawnAtRandomIntervalMaximum = 3.5f;

            spawner8.spawnAtRandomIntervalMinimum = 1;
            spawner8.spawnAtRandomIntervalMaximum = 3.5f;

            spawner9.spawnAtRandomIntervalMinimum = 1;
            spawner9.spawnAtRandomIntervalMaximum = 3.5f;

            spawner10.spawnAtRandomIntervalMinimum = 1;
            spawner10.spawnAtRandomIntervalMaximum = 3.5f;

            spawner11.spawnAtRandomIntervalMinimum = 1;
            spawner11.spawnAtRandomIntervalMaximum = 3.5f;

            spawner12.spawnAtRandomIntervalMinimum = 1;
            spawner12.spawnAtRandomIntervalMaximum = 3.5f;

            spawner13.spawnAtRandomIntervalMinimum = 1;
            spawner13.spawnAtRandomIntervalMaximum = 3.5f;

            minValue = 1;
            maxValue = 3.5f;
        }

       if (currentLvl >= 7 && currentLvl < 15)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.7f;
            spawner1.spawnAtRandomIntervalMaximum = 3f;

            spawner2.spawnAtRandomIntervalMinimum = 0.7f;
            spawner2.spawnAtRandomIntervalMaximum = 3f;

            spawner3.spawnAtRandomIntervalMinimum = 0.7f;
            spawner3.spawnAtRandomIntervalMaximum = 3f;

            spawner4.spawnAtRandomIntervalMinimum = 0.7f;
            spawner4.spawnAtRandomIntervalMaximum = 3f;

            spawner5.spawnAtRandomIntervalMinimum = 0.7f;
            spawner5.spawnAtRandomIntervalMaximum = 3f;

            spawner6.spawnAtRandomIntervalMinimum = 0.7f;
            spawner6.spawnAtRandomIntervalMaximum = 3f;

            spawner7.spawnAtRandomIntervalMinimum = 0.7f;
            spawner7.spawnAtRandomIntervalMaximum = 3f;

            spawner8.spawnAtRandomIntervalMinimum = 0.7f;
            spawner8.spawnAtRandomIntervalMaximum = 3f;

            spawner9.spawnAtRandomIntervalMinimum = 0.7f;
            spawner9.spawnAtRandomIntervalMaximum = 3f;

            spawner10.spawnAtRandomIntervalMinimum = 0.7f;
            spawner10.spawnAtRandomIntervalMaximum = 3f;

            spawner11.spawnAtRandomIntervalMinimum = 0.7f;
            spawner11.spawnAtRandomIntervalMaximum = 3f;

            spawner12.spawnAtRandomIntervalMinimum = 0.7f;
            spawner12.spawnAtRandomIntervalMaximum = 3f;

            spawner13.spawnAtRandomIntervalMinimum = 0.7f;
            spawner13.spawnAtRandomIntervalMaximum = 3f;

            minValue = 0.7f;
            maxValue = 3f;
        }

       if (currentLvl >= 15 && currentLvl < 30)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.4f;
            spawner1.spawnAtRandomIntervalMaximum = 2.5f;

            spawner2.spawnAtRandomIntervalMinimum = 0.4f;
            spawner2.spawnAtRandomIntervalMaximum = 2.5f;

            spawner3.spawnAtRandomIntervalMinimum = 0.4f;
            spawner3.spawnAtRandomIntervalMaximum = 2.5f;

            spawner4.spawnAtRandomIntervalMinimum = 0.4f;
            spawner4.spawnAtRandomIntervalMaximum = 2.5f;

            spawner5.spawnAtRandomIntervalMinimum = 0.4f;
            spawner5.spawnAtRandomIntervalMaximum = 2.5f;

            spawner6.spawnAtRandomIntervalMinimum = 0.4f;
            spawner6.spawnAtRandomIntervalMaximum = 2.5f;

            spawner7.spawnAtRandomIntervalMinimum = 0.4f;
            spawner7.spawnAtRandomIntervalMaximum = 2.5f;

            spawner8.spawnAtRandomIntervalMinimum = 0.4f;
            spawner8.spawnAtRandomIntervalMaximum = 2.5f;

            spawner9.spawnAtRandomIntervalMinimum = 0.4f;
            spawner9.spawnAtRandomIntervalMaximum = 2.5f;

            spawner10.spawnAtRandomIntervalMinimum = 0.4f;
            spawner10.spawnAtRandomIntervalMaximum = 2.5f;

            spawner11.spawnAtRandomIntervalMinimum = 0.4f;
            spawner11.spawnAtRandomIntervalMaximum = 2.5f;

            spawner12.spawnAtRandomIntervalMinimum = 0.4f;
            spawner12.spawnAtRandomIntervalMaximum = 2.5f;

            spawner13.spawnAtRandomIntervalMinimum = 0.4f;
            spawner13.spawnAtRandomIntervalMaximum = 2.5f;

            minValue = 0.4f;
            maxValue = 2.5f;
        }

       if (currentLvl >= 30 && currentLvl < 40)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.2f;
            spawner1.spawnAtRandomIntervalMaximum = 2f;

            spawner2.spawnAtRandomIntervalMinimum = 0.2f;
            spawner2.spawnAtRandomIntervalMaximum = 2f;

            spawner3.spawnAtRandomIntervalMinimum = 0.2f;
            spawner3.spawnAtRandomIntervalMaximum = 2f;

            spawner4.spawnAtRandomIntervalMinimum = 0.2f;
            spawner4.spawnAtRandomIntervalMaximum = 2f;

            spawner5.spawnAtRandomIntervalMinimum = 0.2f;
            spawner5.spawnAtRandomIntervalMaximum = 2f;

            spawner6.spawnAtRandomIntervalMinimum = 0.2f;
            spawner6.spawnAtRandomIntervalMaximum = 2f;

            spawner7.spawnAtRandomIntervalMinimum = 0.2f;
            spawner7.spawnAtRandomIntervalMaximum = 2f;

            spawner8.spawnAtRandomIntervalMinimum = 0.2f;
            spawner8.spawnAtRandomIntervalMaximum = 2f;

            spawner9.spawnAtRandomIntervalMinimum = 0.2f;
            spawner9.spawnAtRandomIntervalMaximum = 2f;

            spawner10.spawnAtRandomIntervalMinimum = 0.2f;
            spawner10.spawnAtRandomIntervalMaximum = 2f;

            spawner11.spawnAtRandomIntervalMinimum = 0.2f;
            spawner11.spawnAtRandomIntervalMaximum = 2f;

            spawner12.spawnAtRandomIntervalMinimum = 0.2f;
            spawner12.spawnAtRandomIntervalMaximum = 2f;

            spawner13.spawnAtRandomIntervalMinimum = 0.2f;
            spawner13.spawnAtRandomIntervalMaximum = 2f;

            minValue = 0.2f;
            maxValue = 2f;
        }

       if (currentLvl >= 40 && currentLvl < 70)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.1f;
            spawner1.spawnAtRandomIntervalMaximum = 1.6f;

            spawner2.spawnAtRandomIntervalMinimum = 0.1f;
            spawner2.spawnAtRandomIntervalMaximum = 1.6f;

            spawner3.spawnAtRandomIntervalMinimum = 0.1f;
            spawner3.spawnAtRandomIntervalMaximum = 1.6f;

            spawner4.spawnAtRandomIntervalMinimum = 0.1f;
            spawner4.spawnAtRandomIntervalMaximum = 1.6f;

            spawner5.spawnAtRandomIntervalMinimum = 0.1f;
            spawner5.spawnAtRandomIntervalMaximum = 1.6f;

            spawner6.spawnAtRandomIntervalMinimum = 0.1f;
            spawner6.spawnAtRandomIntervalMaximum = 1.6f;

            spawner7.spawnAtRandomIntervalMinimum = 0.1f;
            spawner7.spawnAtRandomIntervalMaximum = 1.6f;

            spawner8.spawnAtRandomIntervalMinimum = 0.1f;
            spawner8.spawnAtRandomIntervalMaximum = 1.6f;

            spawner9.spawnAtRandomIntervalMinimum = 0.1f;
            spawner9.spawnAtRandomIntervalMaximum = 1.6f;

            spawner10.spawnAtRandomIntervalMinimum = 0.1f;
            spawner10.spawnAtRandomIntervalMaximum = 1.6f;

            spawner11.spawnAtRandomIntervalMinimum = 0.1f;
            spawner11.spawnAtRandomIntervalMaximum = 1.6f;

            spawner12.spawnAtRandomIntervalMinimum = 0.1f;
            spawner12.spawnAtRandomIntervalMaximum = 1.6f;

            spawner13.spawnAtRandomIntervalMinimum = 0.1f;
            spawner13.spawnAtRandomIntervalMaximum = 1.6f;

            minValue = 0.1f;
            maxValue = 1.6f;
        }

       if (currentLvl >= 70 && currentLvl < 100)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.1f;
            spawner1.spawnAtRandomIntervalMaximum = 1.2f;

            spawner2.spawnAtRandomIntervalMinimum = 0.1f;
            spawner2.spawnAtRandomIntervalMaximum = 1.2f;

            spawner3.spawnAtRandomIntervalMinimum = 0.1f;
            spawner3.spawnAtRandomIntervalMaximum = 1.2f;

            spawner4.spawnAtRandomIntervalMinimum = 0.1f;
            spawner4.spawnAtRandomIntervalMaximum = 1.2f;

            spawner5.spawnAtRandomIntervalMinimum = 0.1f;
            spawner5.spawnAtRandomIntervalMaximum = 1.2f;

            spawner6.spawnAtRandomIntervalMinimum = 0.1f;
            spawner6.spawnAtRandomIntervalMaximum = 1.2f;

            spawner7.spawnAtRandomIntervalMinimum = 0.1f;
            spawner7.spawnAtRandomIntervalMaximum = 1.2f;

            spawner8.spawnAtRandomIntervalMinimum = 0.1f;
            spawner8.spawnAtRandomIntervalMaximum = 1.2f;

            spawner9.spawnAtRandomIntervalMinimum = 0.1f;
            spawner9.spawnAtRandomIntervalMaximum = 1.2f;

            spawner10.spawnAtRandomIntervalMinimum = 0.1f;
            spawner10.spawnAtRandomIntervalMaximum = 1.2f;

            spawner11.spawnAtRandomIntervalMinimum = 0.1f;
            spawner11.spawnAtRandomIntervalMaximum = 1.2f;

            spawner12.spawnAtRandomIntervalMinimum = 0.1f;
            spawner12.spawnAtRandomIntervalMaximum = 1.2f;

            spawner13.spawnAtRandomIntervalMinimum = 0.1f;
            spawner13.spawnAtRandomIntervalMaximum = 1.2f;

            minValue = 0.1f;
            maxValue = 1.2f;
        }

       if (currentLvl >= 100)
        {
            spawner1.spawnAtRandomIntervalMinimum = 0.1f;
            spawner1.spawnAtRandomIntervalMaximum = 0.8f;

            spawner2.spawnAtRandomIntervalMinimum = 0.1f;
            spawner2.spawnAtRandomIntervalMaximum = 0.8f;

            spawner3.spawnAtRandomIntervalMinimum = 0.1f;
            spawner3.spawnAtRandomIntervalMaximum = 0.8f;

            spawner4.spawnAtRandomIntervalMinimum = 0.1f;
            spawner4.spawnAtRandomIntervalMaximum = 0.8f;

            spawner5.spawnAtRandomIntervalMinimum = 0.1f;
            spawner5.spawnAtRandomIntervalMaximum = 0.8f;

            spawner6.spawnAtRandomIntervalMinimum = 0.1f;
            spawner6.spawnAtRandomIntervalMaximum = 0.8f;

            spawner7.spawnAtRandomIntervalMinimum = 0.1f;
            spawner7.spawnAtRandomIntervalMaximum = 0.8f;

            spawner8.spawnAtRandomIntervalMinimum = 0.1f;
            spawner8.spawnAtRandomIntervalMaximum = 0.8f;

            spawner9.spawnAtRandomIntervalMinimum = 0.1f;
            spawner9.spawnAtRandomIntervalMaximum = 0.8f;

            spawner10.spawnAtRandomIntervalMinimum = 0.1f;
            spawner10.spawnAtRandomIntervalMaximum = 0.8f;

            spawner11.spawnAtRandomIntervalMinimum = 0.1f;
            spawner11.spawnAtRandomIntervalMaximum = 0.8f;

            spawner12.spawnAtRandomIntervalMinimum = 0.1f;
            spawner12.spawnAtRandomIntervalMaximum = 0.8f;

            spawner13.spawnAtRandomIntervalMinimum = 0.1f;
            spawner13.spawnAtRandomIntervalMaximum = 0.8f;

            minValue = 0.1f;
            maxValue = 0.8f;
        }

        
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


        //If player collides with Rigidbody powerup
        if (other.gameObject.tag == "PickUpRB")
        {
            iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            player.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(RBBall());
        }

        //If player collides with Resize powerup
        if (other.gameObject.CompareTag("PickUpResize"))
        {
            iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(ResizeBall());
        }

        //If player collides with Spawncount powerup
        if (other.gameObject.CompareTag("PickUpSpawnCount"))
        {
            iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(SpawnCountBall());

        }

        //If player collides with Resize powerup
        if (other.gameObject.CompareTag("PickUpResizeLarger"))
        {
            iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            StartCoroutine(ResizeBallLarger());
        }

        //If player collides with Movement powerup
        if (other.gameObject.CompareTag("PickUpChangeMovementSpeed"))
        {
            iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            StartCoroutine(ChangeMovmentTemp());
        }
    }
    
    //Resize powerup
    IEnumerator ResizeBall()
    {
        powerupText.text = "BALL SIZE REDUCED!";
        PlayerObject.gameObject.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
        powerupScore = powerupScore + 5;
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
        powerupScore = powerupScore + 5;
        yield return new WaitForSeconds(5);
        powerupText.text = "";
        gameObject.layer = 9;
    }

    //Spawncount powerup
    IEnumerator SpawnCountBall()
    {
        powerupText.text = "SPAWN COUNT REDUCED!";
        spawner1.spawnAtRandomIntervalMinimum = 2;
        spawner1.spawnAtRandomIntervalMaximum = 4;

        spawner2.spawnAtRandomIntervalMinimum = 2;
        spawner2.spawnAtRandomIntervalMaximum = 4;

        spawner3.spawnAtRandomIntervalMinimum = 2;
        spawner3.spawnAtRandomIntervalMaximum = 4;

        spawner4.spawnAtRandomIntervalMinimum = 2;
        spawner4.spawnAtRandomIntervalMaximum = 4;

        spawner5.spawnAtRandomIntervalMinimum = 2;
        spawner5.spawnAtRandomIntervalMaximum = 4;

        spawner6.spawnAtRandomIntervalMinimum = 2;
        spawner6.spawnAtRandomIntervalMaximum = 4;

        spawner7.spawnAtRandomIntervalMinimum = 2;
        spawner7.spawnAtRandomIntervalMaximum = 4;

        spawner8.spawnAtRandomIntervalMinimum = 2;
        spawner8.spawnAtRandomIntervalMaximum = 4;

        spawner9.spawnAtRandomIntervalMinimum = 2;
        spawner9.spawnAtRandomIntervalMaximum = 4;

        spawner10.spawnAtRandomIntervalMinimum = 2;
        spawner10.spawnAtRandomIntervalMaximum = 4;

        spawner11.spawnAtRandomIntervalMinimum = 2;
        spawner11.spawnAtRandomIntervalMaximum = 4;

        spawner12.spawnAtRandomIntervalMinimum = 2;
        spawner12.spawnAtRandomIntervalMaximum = 4;

        spawner13.spawnAtRandomIntervalMinimum = 2;
        spawner13.spawnAtRandomIntervalMaximum = 4;

        //add score
        powerupScore = powerupScore + 5;

        yield return new WaitForSeconds(6);

        powerupText.text = "";
        spawner1.spawnAtRandomIntervalMinimum = minValue;
        spawner1.spawnAtRandomIntervalMaximum = maxValue;

        spawner2.spawnAtRandomIntervalMinimum = minValue;
        spawner2.spawnAtRandomIntervalMaximum = maxValue;

        spawner3.spawnAtRandomIntervalMinimum = minValue;
        spawner3.spawnAtRandomIntervalMaximum = maxValue;

        spawner4.spawnAtRandomIntervalMinimum = minValue;
        spawner4.spawnAtRandomIntervalMaximum = maxValue;

        spawner5.spawnAtRandomIntervalMinimum = minValue;
        spawner5.spawnAtRandomIntervalMaximum = maxValue;

        spawner6.spawnAtRandomIntervalMinimum = minValue;
        spawner6.spawnAtRandomIntervalMaximum = maxValue;

        spawner7.spawnAtRandomIntervalMinimum = minValue;
        spawner7.spawnAtRandomIntervalMaximum = maxValue;

        spawner8.spawnAtRandomIntervalMinimum = minValue;
        spawner8.spawnAtRandomIntervalMaximum = maxValue;

        spawner9.spawnAtRandomIntervalMinimum = minValue;
        spawner9.spawnAtRandomIntervalMaximum = maxValue;

        spawner10.spawnAtRandomIntervalMinimum = minValue;
        spawner10.spawnAtRandomIntervalMaximum = maxValue;

        spawner11.spawnAtRandomIntervalMinimum = minValue;
        spawner11.spawnAtRandomIntervalMaximum = maxValue;

        spawner12.spawnAtRandomIntervalMinimum = minValue;
        spawner12.spawnAtRandomIntervalMaximum = maxValue;

        spawner13.spawnAtRandomIntervalMinimum = minValue;
        spawner13.spawnAtRandomIntervalMaximum = maxValue;

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

        //Clear timer when game ends
        if (stopTimer == true)
        {
            timerText.text = "";
        }
        else if(levelComplete == true){

        }
        else
        {
            float t = Time.time - startTime;

            seconds = Mathf.RoundToInt(t);

            currentScore = seconds + pastScore + powerupScore;

            timerText.text = "SCORE:" + currentScore;
        }
        progressBar.value = seconds; 

        if(progressBar.value == 45)
        {
            if (!onetime)
            {
                LevelComplete();
                onetime = true;
            }
            
        }
        if(progressBar.value == 25)
        {
            spawnerBig1.StopSpawn();
            spawnerBig2.StopSpawn();
            spawnerBig3.StopSpawn();
        }
        if(progressBar.value == 38)
        {
            spawner1.StopSpawn();
            spawner2.StopSpawn();
            spawner3.StopSpawn();
            spawner4.StopSpawn();
            spawner5.StopSpawn();
            spawner6.StopSpawn();
            spawner7.StopSpawn();
            spawner8.StopSpawn();
            spawner9.StopSpawn();
            spawner10.StopSpawn();
            spawner11.StopSpawn();
            spawner12.StopSpawn();
            spawner13.StopSpawn();
            spawnerPowerupResize.StopSpawn();
            spawnerPowerupSpawnCount.StopSpawn();
            spawnerPowerupResizeLarger.StopSpawn();
        }
    }
    //Game over code that runs when player hits game over trigger
    public void GameOver()
    {

        //Stop Music
        theSong.Stop();

        //Get player's highest saved score
        int highscore = PlayerPrefs.GetInt("Score");

        //Clear timer
        timerText.text = "";
  
        //Create game over text
        gameOverText.text = "GAME OVER!";

        PlayerPrefs.SetInt("PastScore", 0);

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
        timerScoreText.text = "YOUR SCORE:" + currentScore;

        //Show players highest score
        highscoreText.text = "HIGHEST SCORE:" + highscore;
        powerupText.text = "";

        //Stop timer
        stopTimer = true;

        //If player score is over players highest score, overwrite and save as new highscore
        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("Score", currentScore);
        }

        //Delay so player does not miss out on anything while watching ad 
        StartCoroutine(Wait());

        //Setup mute and unmute buttons
        if(AudioListener.pause == true)
        {
            gameoverMuteButton.SetActive(true);
        }
        else if(AudioListener.pause == false){
            gameoverUnmuteButton.SetActive(true);
        }

        //Show menu buttons
        restartButton.SetActive(true);
        leaderboardButton.SetActive(true);
        helpButton.SetActive(true);

    }

    public void LevelComplete()
    {
        //Show next level button
        nextLevelButton.SetActive(true);

        //freeze player
        player.constraints = RigidbodyConstraints.FreezeAll;

        //Stop Music
        theSong.Stop();

        //Set next colour scheme
        if (arrayPos >= colours.Length - 1)
        {
            arrayPos = 0;
            PlayerPrefs.SetInt("LevelColour", arrayPos);
        }
        else
        {
            arrayPos += 1;
            PlayerPrefs.SetInt("LevelColour", arrayPos);
        }

        //Create level complete text
        gameOverText.text = "Level Complete!";

        //Show players score
        timerScoreText.text = "Next Level:" + nextLvl;

        //Next level variables
        currentLvl = currentLvl + 1;

        PlayerPrefs.SetInt("Level", currentLvl);

        PlayerPrefs.SetInt("PastScore", currentScore);

        levelComplete = true;

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


    //Restart game code
    public void restart()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject go in ball)
            Destroy(go);
        GameObject[] movement = GameObject.FindGameObjectsWithTag("PickUpChangeMovementSpeed");
        foreach (GameObject go in movement)
            Destroy(go);
        GameObject[] rb = GameObject.FindGameObjectsWithTag("PickUpRB");
        foreach (GameObject go in rb)
            Destroy(go);
        GameObject[] resize = GameObject.FindGameObjectsWithTag("PickUpResize");
        foreach (GameObject go in resize)
            Destroy(go);
        GameObject[] resizeLarger = GameObject.FindGameObjectsWithTag("PickUpResizeLarger");
        foreach (GameObject go in resizeLarger)
            Destroy(go);
        GameObject[] spawnCount = GameObject.FindGameObjectsWithTag("PickUpSpawnCount");
        foreach (GameObject go in spawnCount)
            Destroy(go);
        //Reset score 
        seconds = 0;
        //Reload game scene
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;

    }

    public void nextLevel()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject go in ball)
            Destroy(go);
        GameObject[] movement = GameObject.FindGameObjectsWithTag("PickUpChangeMovementSpeed");
        foreach (GameObject go in movement)
            Destroy(go);
        GameObject[] rb = GameObject.FindGameObjectsWithTag("PickUpRB");
        foreach (GameObject go in rb)
            Destroy(go);
        GameObject[] resize = GameObject.FindGameObjectsWithTag("PickUpResize");
        foreach (GameObject go in resize)
            Destroy(go);
        GameObject[] resizeLarger = GameObject.FindGameObjectsWithTag("PickUpResizeLarger");
        foreach (GameObject go in resizeLarger)
            Destroy(go);
        GameObject[] spawnCount = GameObject.FindGameObjectsWithTag("PickUpSpawnCount");
        foreach (GameObject go in spawnCount)
            Destroy(go);
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

    public void gameoverMuteSound()
    {
        AudioListener.pause = false;

        AudioListener.volume = 1;
        gameoverMuteButton.SetActive(false);
        gameoverUnmuteButton.SetActive(true);
    }

    public void gameoverUnmuteSound()
    {
        AudioListener.pause = true;

        AudioListener.volume = 0;
        gameoverUnmuteButton.SetActive(false);
        gameoverMuteButton.SetActive(true);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

}