using UnityEngine;
using UnityEngine.UI;

public class OnScreenText : MonoBehaviour
{
    public Text ScoreText;
    public Text TimeText;
    public Text GoldText;
    public Text WaveText;
    public Text WaveStartText;
    public Wallet Wallet;
    public GameStopwatch Stopwatch;
    public Waves Waves;

    private void Update()
    {
        ShowScore();
        ShowTime();
        ShowGold();
        ShowWave();
        if (Waves.CurrentMode == Waves.Mode.Prep)
            ShowWaveStart();
        else ShowEnemiesRemaining();
    }

    private void ShowScore()
    {
        ScoreText.text = "Score: " + Score.GetScoreString();
    }

    private void ShowTime()
    {
        TimeText.text = "Time Elapsed: " + Stopwatch.GetTimeAsString();
    }

    private void ShowGold()
    {
        GoldText.text = "Current Gold: " + Wallet.GetMoney();
    }

    private void ShowWave()
    {
        WaveText.text = "Wave " + Waves.GetCurrentWave();
    }

    private void ShowWaveStart()
    {
        WaveStartText.text = "Time Until Wave Start: " + Waves.Timer.GetTimeAsString();
    }

    private void ShowEnemiesRemaining()
    {
        WaveStartText.text = "Enemies Remaining: " + Waves.GetEnemiesRemaining();
    }
}
