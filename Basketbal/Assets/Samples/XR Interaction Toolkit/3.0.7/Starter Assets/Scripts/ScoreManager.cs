using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TimerController timerController;
    public int pointsToReceive = 2;         // default 2

    private int score = 0;
    private bool allowedToScore = false;

    /// <summary>
    /// When ball goes through hoop
    /// </summary>
    public void IncreaseScore()
    {
        if (!allowedToScore) return;

        score += pointsToReceive;
        scoreText.text = "Score: " + score;
    }

    public void StartTimeGamemode()
    {
        timerController.countDown = true;
        timerController.timeValue = 60;
        timerController.StartTimer();
        score = 0;
        allowedToScore = true;
        timerController.timerDone += OnTimerDone;
    }

    private void OnTimerDone(object sender, EventArgs e)
    {
        allowedToScore = false;
        timerController.timerDone -= OnTimerDone;
    }

    public void SetPointsToReceive(int points)
    {
        if (allowedToScore) pointsToReceive = points;
    }

    public void setText(string text)
    {
        scoreText.text = text;
    }
}
