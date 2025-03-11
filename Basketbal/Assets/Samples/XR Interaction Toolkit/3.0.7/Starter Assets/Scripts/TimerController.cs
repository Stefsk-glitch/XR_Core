using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float timeValue = 0;
    public bool timerRunning = false;
    public bool countDown = false;

    void Update()
    {
        if (timerRunning)
        {
            if (countDown)
            {
                if (timeValue > 0)
                {
                    timeValue -= Time.deltaTime;
                }
                else
                {
                    timeValue = 0;
                    timerRunning = false; 
                }
            }
            else
            {
                timeValue += Time.deltaTime; 
            }

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        timerRunning = false;
        timeValue = 0;
        UpdateTimerText();
    }

    public void SetTime(float minutes)
    {
        timeValue = minutes * 60;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeValue / 60);
        int seconds = Mathf.FloorToInt(timeValue % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
