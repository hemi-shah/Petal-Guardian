using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool GameOver { get; private set; } = false;
    private bool firstPlantOrFlowerExists = false;
    private int plantFlowerCount = 0;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup WinScreenCanvasGroup;
    public CanvasGroup LoseScreenCanvasGroup;
    public CanvasGroup GameplayCanvasGroup;
    private GameObject gameElements;
    public GameTimer Timer;
    [FormerlySerializedAs("stopwatch")] public GameStopwatch Stopwatch;
    private Wallet wallet;
    public bool ShowStartScreen = true;
    [FormerlySerializedAs("difficulty")] public float Difficulty = 1;
    public Waves Waves;
    public bool GameWon;
    public bool GameStarted = false;
    [FormerlySerializedAs("leftEdgeOfScreenXPos")] public float LeftEdgeOfScreenXPos = -10.5f;
    private Text winScoreText;
    private Text loseScoreText;
    public Music Music;
    public Sounds Sounds;

    private void Awake()
    {
        SetUpVariables();
        foreach (Transform child in gameElements.transform) child.gameObject.SetActive(false);
        if (!ShowStartScreen)
        {
            CanvasGroupDisplayer.Show(GameplayCanvasGroup);
            return;
        }
        CanvasGroupDisplayer.Hide(GameplayCanvasGroup);
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }

    private void Start()
    {
        Music.StopAllMusic();
        Music.PlayMenuMusic();
        Score.Reset();
    }

    private void SetUpVariables()
    {
        Sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>(); 
        Music = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
        loseScoreText = LoseScreenCanvasGroup.GetComponentInChildren<Text>();
        winScoreText = WinScreenCanvasGroup.GetComponentInChildren<Text>();
        gameElements = GameObject.FindGameObjectWithTag("GameElements");
        Timer = GetComponent<GameTimer>();
        Stopwatch = GetComponent<GameStopwatch>();
        wallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
    }

    public void OnStartButtonClick()
    {
        Sounds.PlayStartButtonPressSound();
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        StartGame();
    }

    private void StartGame()
    {
        CanvasGroupDisplayer.Show(GameplayCanvasGroup);
        foreach (Transform child in gameElements.transform) child.gameObject.SetActive(true);
        GameStarted = true;
        Stopwatch.StartStopwatch();
        Waves.StartPlaying();
        wallet.StartGeneratingMoney();
    }

    public void IncreasePlantFlowerCount()
    {
        firstPlantOrFlowerExists = true;
        plantFlowerCount++;
    }

    public void DecreasePlantFlowerCount()
    {
        plantFlowerCount--;
    }
    
    private void Update()
    {
        if (plantFlowerCount < 1 && !GameOver && firstPlantOrFlowerExists)
        {
            Lose();
        }
    }

    public void Lose()
    {
        Sounds.PlayLosingSound();
        GameOver = true;
        print("Game over!");
        CanvasGroupDisplayer.Hide(GameplayCanvasGroup);
        CanvasGroupDisplayer.Show(LoseScreenCanvasGroup);
        loseScoreText.text = "Score: " + Score.GetScoreString();
    }

    public void Win()
    {
        Sounds.PlayVictorySound();
        GameWon = true;
        print("You win!");
        StartCoroutine(WaitToDisplayWin());
        winScoreText.text = "Score: " + Score.GetScoreString();
    }

    private IEnumerator WaitToDisplayWin()
    {
        yield return new WaitForSeconds(1);
        CanvasGroupDisplayer.Hide(GameplayCanvasGroup);
        CanvasGroupDisplayer.Show(WinScreenCanvasGroup);
    }

    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Game");
    }
}
