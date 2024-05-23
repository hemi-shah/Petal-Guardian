using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class TimeUtility : MonoBehaviour
{
    [FormerlySerializedAs("isRunning")] public bool IsRunning;
    protected int TimeRemaining;
    protected string Type = "";
    
    public string GetTimeAsString()
    {
        var minutes = TimeRemaining / 60;
        var seconds = TimeRemaining - (minutes * 60);
        var minutesAsString = $"{minutes:00}";
        var secondsAsString = $"{seconds:00}";
        return minutesAsString + ":" + secondsAsString;
    }

    protected virtual void OnTick()
    {
        
    }

    protected IEnumerator TickOneSecond()
    {
        yield return new WaitForSeconds(1);
        if (IsRunning)
        {
            OnTick();
            if (Type == "timer")
            {
                TimeRemaining--;
                if (TimeRemaining > 0)
                {
                    StartCoroutine(TickOneSecond());
                }
                else
                {
                    TimeRemaining = 0;
                    IsRunning = false;
                }
            }
            else
            {
                TimeRemaining++;
                StartCoroutine(TickOneSecond());
            }
        }
    }
}
