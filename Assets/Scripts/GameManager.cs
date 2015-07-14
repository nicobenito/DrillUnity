using UnityEngine;
using System.Collections;

namespace Drill
{
	using System.Collections.Generic;       //Allows us to use Lists. 
	using UnityEngine.UI;

	public class GameManager : MonoBehaviour
	{
		
		public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
		private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
		private int level = 1;
		private bool isGameOver = false;
		//player
		private GameObject playerRef;
		private PlayerController playerController;
		//canvas
		public GameObject canvas;
		private GameObject levelImage;
		private Text playerLifeText;
		private Text levelNumber;


		//Awake is always called before any Start functions
		void Awake()
		{
			//Check if instance already exists
			if (instance == null)
				instance = this;
			
			//If instance already exists and it's not this:
			else if (instance != this)
				Destroy(gameObject);    

			DontDestroyOnLoad(gameObject);
			boardScript = GetComponent<BoardManager>();
			
			//Call the InitGame function to initialize the first level 
			//InitGame();
		}
		//To restart or level change
		void OnLevelWasLoaded()
		{
			//Call InitGame to initialize our level.
			InitGame();
		}
		
		//Initializes the game for each level.
		public void InitGame()
		{
			Instantiate (canvas);
			//set Level number
			levelNumber = GameObject.Find ("LevelNumber").GetComponent<Text> ();
			levelNumber.text = "Level "+ level;
			//player reference and lifeText setup
			playerRef = GameObject.Find ("Player");
			playerController = playerRef.GetComponent<PlayerController>();
			levelImage = GameObject.Find ("LevelImage");
			levelImage.SetActive (false);
			playerLifeText = GameObject.Find ("LifePlayer").GetComponent<Text>();
			//Call the SetupScene function of the BoardManager script, pass it current level number.
			boardScript.SetupScene(level);
			isGameOver=false;
			
		}

		public void Restart()
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		public void GameOver()
		{
			levelImage.SetActive(true);
			isGameOver = true;

		}

		void Update()
		{
			playerLifeText.text = "Life " + playerController.life;

			if (!isGameOver && !playerController.isAlive)
				GameOver ();

			if (isGameOver && Input.GetKey (KeyCode.Backspace)) 
			{
				Restart();
			}

			if (playerController.levelWin) 
			{
				level++;
				Restart();
			}
		}
	}
}