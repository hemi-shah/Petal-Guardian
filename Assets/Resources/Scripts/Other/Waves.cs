using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    [FormerlySerializedAs("timer")] public GameTimer Timer;
    private Game game;
    private const int InitialPrepSeconds = 30;
    private const int TimeBetweenWaves = 15;
    private int enemyCount = 0;
    private int waveNumber = -1;
    private List<Wave> waveList;
    private Wave currentWave;
    private float minSecondsBeforeEnemySpawn = 3;
    private float maxSecondsBeforeEnemySpawn = 5;
    private GameObject enemyPlaceholder;
    private PlaceEnemies enemyPlacer;
    private const bool ShouldPrint = true;
    public List<GameObject> WaveOneEnemies;
    public List<GameObject> WaveTwoEnemies;
    public List<GameObject> WaveThreeEnemies;
    public Image BottomReadouts;
    public Image ShopAreaBackground;
    private Color redColor = new Color(100/255f, 0f,0f);
    private Color greenColor = new Color(50/255f, 100/255f, 0f);

    public enum Mode
    {
        Prep,
        Playing,
        NotStarted,
        Won
    }

    [FormerlySerializedAs("currentMode")] public Mode CurrentMode = Mode.NotStarted;

    private void Awake()
    {
        Timer = GetComponent<GameTimer>();
        game = GetComponent<Game>();
        enemyPlacer = GetComponent<PlaceEnemies>();
        waveList = new List<Wave>()
        {
            new Wave(WaveOneEnemies),
            new Wave(WaveTwoEnemies),
            new Wave(WaveThreeEnemies)
        };
        currentWave = waveList[0];
    }

    public void StartPlaying()
    {
        waveNumber++;
        CurrentMode = Mode.Prep;
        if(ShouldPrint) print("Starting initial prep timer...");
        Timer.StartTimer(InitialPrepSeconds);
    }

    private void Update()
    {
        if (game.GameOver) return;
        switch (CurrentMode)
        {
            case Mode.Prep:
                if (CheckForWin()) return;
                if (!Timer.IsRunning)
                {
                    if(ShouldPrint) print("Prep time over! Starting wave " + (waveNumber+1) + ", Difficulty: " + game.Difficulty);
                    CurrentMode = Mode.Playing;
                    BottomReadouts.color = redColor;
                    ShopAreaBackground.color = redColor;
                    StartWave();
                }
                break;
            case Mode.Playing:
                if (currentWave.Count <= 0 && enemyCount <= 0)
                {
                    waveNumber++;
                    if (CheckForWin()) return;
                    print("Starting prep for next wave (Wave " + (waveNumber+1) + ")");
                    Timer.StartTimer(TimeBetweenWaves);
                    game.Music.PlayPrepMusic();
                    CurrentMode = Mode.Prep;
                    BottomReadouts.color = greenColor;
                    ShopAreaBackground.color = greenColor;
                }
                break;
        }
    }

    private bool CheckForWin()
    {
        if (AllWavesHaveBeenLoaded() && enemyCount <= 0 && !game.GameWon)
        {
            game.Win();
            CurrentMode = Mode.Won;
            return true;
        }
        return false;
    }

    private bool AllWavesHaveBeenLoaded()
    {
        return waveNumber >= waveList.Count;
    }
    private void SetNextWave()
    {
        if(waveNumber >= 0) UpdateDifficulty();
        if (AllWavesHaveBeenLoaded()) return;
        currentWave = waveList[waveNumber];
        StartCoroutine(SpawnEnemies());
    }

    private void UpdateDifficulty()
    {
        game.Difficulty += 0.05f;
        minSecondsBeforeEnemySpawn /= game.Difficulty;
        maxSecondsBeforeEnemySpawn /= game.Difficulty;
    }
    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    private void StartWave()
    {
        SetNextWave();
        game.Music.PlayBattleMusic();
    }

    private IEnumerator SpawnEnemies()
    {
        if (game.GameWon) yield break; 
        SpawnEnemy(currentWave.GetEnemyToSpawn());
        if (currentWave.Count <= 0)
        {
            if(ShouldPrint) print("All enemies spawned for wave " + (waveNumber + 1));
            yield break;
        }
        yield return new WaitForSeconds(Random.Range(minSecondsBeforeEnemySpawn, maxSecondsBeforeEnemySpawn)); 
        StartCoroutine(SpawnEnemies());
    }
    private void SpawnEnemy(GameObject enemy)
    {
        enemyPlacer.SpawnOneEnemy(enemy);
    }

    public int GetCurrentWave()
    {
        return (waveNumber + 1);
    }

    public int GetEnemiesRemaining()
    {
        return currentWave.Count + enemyCount;
    }
}