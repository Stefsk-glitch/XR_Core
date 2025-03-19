using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TimerController timerController;
    public int pointsToReceive = 2;         // default 2
    public XROrigin player;

    private int yPos = 0;
    private int score = 0;
    private bool allowedToScore = false;

    /// <summary>
    /// When ball goes through hoop
    /// </summary>
    public void IncreaseScore()
    {
        tpPLayer();

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

    public void StartDistanceGamemode()
    {
        timerController.countDown = false;
        timerController.timeValue = 0;
        timerController.StartTimer();
        score = 0;
        allowedToScore = false;
        player.transform.position = new Vector3(yPos, 0, 0);
        player.GetComponent<CharacterController>().enabled = false;
    }

    private void OnTimerDone(object sender, EventArgs e)
    {
        allowedToScore = false;
        timerController.timerDone -= OnTimerDone;
    }

    private void tpPLayer()
    {
        if (yPos == -16)
        {
            timerController.StopTimer();
            player.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            yPos -= 2;
            player.transform.position = new Vector3(yPos, 0, 0);
        }
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
