public class GameTimer : TimeUtility
{
    private void Awake()
    {
        Type = "timer";
    }
    
    public void StartTimer(int durationInSeconds)
    {
        if (IsRunning) return;
        IsRunning = true;
        TimeRemaining = durationInSeconds;
        StartCoroutine(TickOneSecond());
    }

    public void StopTimer()
    {
        IsRunning = false;
    }

    protected override void OnTick()
    {
     //update readouts   
    }
}
