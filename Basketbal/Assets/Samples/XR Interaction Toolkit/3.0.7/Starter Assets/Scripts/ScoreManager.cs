using UnityEngine;
using UnityEngine.UI;  // Use Unity's default UI text instead of TMP

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TimerController timerContoller;
    public int amountPointToReward = 2;

    private int score = 0;

    public void IncreaseScore()
    {
        score += amountPointToReward; 
        scoreText.text = "Score: " + score;
        timerContoller.StartTimer();
    }

    public void GivePoints(int points)
    {
        amountPointToReward = points;
    }

    public void setText(string text)
    {
        scoreText.text = text;
    }
}
