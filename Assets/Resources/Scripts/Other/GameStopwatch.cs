public class GameStopwatch : TimeUtility
{
    public void StartStopwatch()
    {
        IsRunning = true;
        StartCoroutine(TickOneSecond());
    }

    protected override void OnTick()
    {
        //update readouts
    }
}
