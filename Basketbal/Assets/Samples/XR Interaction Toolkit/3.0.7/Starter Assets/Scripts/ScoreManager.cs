using UnityEngine;
using UnityEngine.UI;  // Use Unity's default UI text instead of TMP

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TimerController timerContoller;

    private int score = 0;

    public void IncreaseScore()
    {
        score++; 
        scoreText.text = "Score: " + score;
        timerContoller.StartTimer();
    }
}
