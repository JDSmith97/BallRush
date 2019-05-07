using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


// Include the namespace required to use Unity UI
using UnityEngine.UI;
using Ez.Pooly;
using System.Collections;
using Lean.Touch;
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

    public static bool gameOver;
    private float startTime;
    private int seconds;
    private bool stopTimer;

    Material material1;
    Material material2;
    Material material3;

    public GameObject mainMenuCanvas;

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

    public int zone1 = 0;
    public int zone2 = 0;
    public int zone3 = 0;
    public int zone4 = 0;
    public int zone5 = 0;

    public GameObject zone1Drop;
    public GameObject zone2Drop;
    public GameObject zone3Drop;
    public GameObject zone4Drop;
    public GameObject zone5Drop;

    public GameObject Lean_Touch;

    public static bool zoneWarning1 = false;
    public static bool zoneWarning2 = false;
    public static bool zoneWarning3 = false;
    public static bool zoneWarning4 = false;
    public static bool zoneWarning5 = false;


    public Rigidbody zoneNo1;
    public Rigidbody zoneNo2;
    public Rigidbody zoneNo3;
    public Rigidbody zoneNo4;

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
        // Authenticate
        Social.localUser.Authenticate(ProcessAuthentication);

        //reset platform and progress bar
        progressBar.value = 0;
        zoneWarning1 = false;
        zoneWarning2 = false;
        zoneWarning3 = false;
        zoneWarning4 = false;
        zoneWarning5 = false;

        //play time
        Time.timeScale = 1;

        Lean_Touch = GameObject.Find("LeanTouch");

        Lean_Touch.GetComponent<LeanTouch>().enabled = true;

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
        nextLevelButton.SetActive(false);

        mainMenuCanvas.SetActive(true);

        //sound
        gameAudio = GetComponent<AudioSource>();

        //set to 0
        progressBar.value = 0;

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
        spawnerPowerupSpawnCount = spawnerSpawnCount.GetComponent<PoolySpawner>();
        spawnerBig1 = spawnerBigBall1.GetComponent<PoolySpawner>();
        spawnerBig2 = spawnerBigBall2.GetComponent<PoolySpawner>();
        spawnerBig3 = spawnerBigBall3.GetComponent<PoolySpawner>();
        //---------------------------------------------------------------------------------------------


        pastScore = PlayerPrefs.GetInt("PastScore");

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

        //randomise zone drops
        zone1 = Random.Range(1, 6);
        zone2 = Random.Range(1, 6);
        zone3 = Random.Range(1, 6);
        zone4 = Random.Range(1, 6);
        zone5 = Random.Range(1, 6);
        while (zone2 == zone1)
        {
            zone2 = Random.Range(1, 6);
        }
        zone3 = Random.Range(1, 6);
        while(zone3 == zone2 || zone3 == zone1)
        {
            zone3 = Random.Range(1, 6);
        }
        zone4 = Random.Range(1, 6);
        while (zone4 == zone3 || zone4 == zone2 || zone4 == zone1)
        {
            zone4 = Random.Range(1, 6);
        }
        zone5 = Random.Range(1, 6);
        while (zone5 == zone4 || zone5 == zone3 || zone5 == zone2 || zone5 == zone1)
        {
            zone5 = Random.Range(1, 6);
        }


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
        spawnerPowerupSpawnCount.ResumeSpawn();
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

            zone1 = Random.Range(1, 4);
            zone2 = Random.Range(1, 4);

            while(zone1 == zone2)
            {
                Random.Range(1, 4);
            }

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
            Lean_Touch.GetComponent<LeanTouch>().enabled = false;
        }

        if (other.gameObject.CompareTag("ZoneTrigger"))
        {
            player.constraints = RigidbodyConstraints.None;
            Lean_Touch.GetComponent<LeanTouch>().enabled = false;
            //other.GetComponent<LeanChaseRigidbody>().enabled = false;

        }

        if (other.gameObject.CompareTag("ZoneTriggerDrop"))
        {
            GameOver();
        }

        //Game over
        if (other.gameObject.CompareTag("gameover"))
        {
            GameOver();
        }


        //If player collides with Rigidbody powerup
        if (other.gameObject.tag == "PickUpRB")
        {
            //iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            player.constraints = RigidbodyConstraints.FreezePositionY;
            //StartCoroutine(RBBall());
        }

        //If player collides with Resize powerup
        if (other.gameObject.CompareTag("PickUpResize"))
        {
            //iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(ResizeBall());
        }

        //If player collides with Spawncount powerup
        if (other.gameObject.CompareTag("PickUpSpawnCount"))
        {
            //iOSHapticController.instance.TriggerImpactMedium();
            Destroy(other.gameObject);
            gameAudio.PlayOneShot(AudioSource);
            powerupCount++;
            StartCoroutine(SpawnCountBall());

        }

        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(ballBounce());
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

    IEnumerator ballBounce()
    {
        gameObject.GetComponent<LeanChaseRigidbody>().enabled = false;
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.left * 200);
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponent<LeanChaseRigidbody>().enabled = true;
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

    //Wait for zone to change colour
    IEnumerator WaitForZone()
    {
        //change colour
        zoneWarning1 = true;
        yield return new WaitForSeconds(2.5f);
        //release zone
        zoneNo1.constraints = RigidbodyConstraints.None;
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

        //dropzones
        if(progressBar.value == 10)
        {
            if(zone1 == 1)
            {

                zoneWarning1 = true;

            }
            else if(zone1 == 2)
            {

                zoneWarning2 = true;

            }
            else if (zone1 == 3)
            {

                zoneWarning3 = true;

            }
            else if (zone1 == 4)
            {               
                zoneWarning4 = true;
            }
            else
            {
                zoneWarning5 = true;             
            }
        }
        if (currentLvl >= 7 && progressBar.value == 23)
        {
            if (zone2 == 1)
            {
                zoneWarning1 = true;

            }
            else if (zone2 == 2)
            {
                zoneWarning2 = true;
            }
            else if (zone2 == 3)
            {
                zoneWarning3 = true;
            }
            else if (zone2 == 4)
            {
                zoneWarning4 = true;
            }
            else
            {
                zoneWarning5 = true;
            }
        }

        if (currentLvl >= 18 && progressBar.value == 35)
        {
            if (zone3 == 1)
            {
                zoneWarning1 = true;

            }
            else if (zone3 == 2)
            {
                zoneWarning2 = true;
            }
            else if (zone3 == 3)
            {
                zoneWarning3 = true;
            }
            else if (zone3 == 4)
            {
                zoneWarning4 = true;
            }
            else
            {
                zoneWarning5 = true;
            }
        }

        if (currentLvl >= 30 && progressBar.value == 42)
        {
            if (zone4 == 1)
            {
                zoneWarning1 = true;

            }
            else if (zone4 == 2)
            {
                zoneWarning2 = true;
            }
            else if (zone4 == 3)
            {
                zoneWarning3 = true;
            }
            else if (zone4 == 4)
            {
                zoneWarning4 = true;
            }
            else
            {
                zoneWarning5 = true;
            }
        }

        if (progressBar.value == 60)
        {
            if (!onetime)
            {
                LevelComplete();
                onetime = true;
            }
            
        }
        if(progressBar.value == 40)
        {
            spawnerBig1.StopSpawn();
            spawnerBig2.StopSpawn();
            spawnerBig3.StopSpawn();
        }
        if(progressBar.value == 53)
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
            spawnerPowerupMovement.StopSpawn();
        }
    }
    private bool Waited(float seconds)
    {
        float timer = 0;

        float timerMax = 0;

        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }

    //Game over code that runs when player hits game over trigger
    public void GameOver()
    {
        Lean_Touch.GetComponent<LeanTouch>().enabled = false;

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
        else if (powerupCount > 0)
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
            Social.ReportScore(currentScore, "topscore", success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
        }
       
        StartCoroutine(Wait());

        //Setup mute and unmute buttons
        if (AudioListener.pause == true)
        {
            gameoverMuteButton.SetActive(true);
        }
        else if (AudioListener.pause == false)
        {
            gameoverUnmuteButton.SetActive(true);
        }

        //Show menu buttons
        restartButton.SetActive(true);
        leaderboardButton.SetActive(true);

        zoneWarning1 = false;
        zoneWarning2 = false;
        zoneWarning3 = false;
        zoneWarning4 = false;
        zoneWarning5 = false;
    }

    public void ReportScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public void LevelComplete()
    {
        Lean_Touch.GetComponent<LeanTouch>().enabled = false;

        //Show next level button
        nextLevelButton.SetActive(true);

        //freeze player
        player.constraints = RigidbodyConstraints.FreezeAll;

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

        if(Input.touchCount >= 1)
        {
            StartCoroutine(nextLevel());
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(nextLevel());
        }

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

    public void restartButtonClick()
    {
        StartCoroutine(restart());
    }

    //Restart game code
    IEnumerator restart()
    {
        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject go in ball)
            Destroy(go);
        yield return new WaitForSeconds(1.5f);
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

    IEnumerator nextLevel()
    {

        GameObject[] ball = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject go in ball)
            Destroy(go);
        yield return new WaitForSeconds(1.5f);
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

    // This function gets called when Authenticate completes
    void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated");

        }
        else
            Debug.Log("Failed to authenticate");
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

}