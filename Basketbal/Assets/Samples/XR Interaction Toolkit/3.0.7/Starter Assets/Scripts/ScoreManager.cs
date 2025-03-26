using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TimerController timerController;
    public int pointsToReceive = 2;         // default 2
    public XROrigin player;
    public GameObject cylinderPrefab;

    private int xPos = 0;
    private int score = 0;
    private bool allowedToScore = false;
    private bool tpPlayerOnScore = false;
    private GameObject spawnedCylinder;

    /// <summary>
    /// When ball goes through hoop
    /// </summary>
    public void IncreaseScore()
    {
        if (tpPlayerOnScore) tpPLayer();

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
        allowedToScore = true;
        player.GetComponent<CharacterController>().enabled = false;
        tpPlayerOnScore = true;

        if (cylinderPrefab != null && player != null)
        {
            spawnedCylinder = Instantiate(cylinderPrefab, new Vector3(xPos, 0, 0), Quaternion.identity);
        }

        player.transform.position = spawnedCylinder.transform.position + new Vector3(0.5f, 0, 1.25f);
    }

    private void OnTimerDone(object sender, EventArgs e)
    {
        allowedToScore = false;
        tpPlayerOnScore = false;
        timerController.timerDone -= OnTimerDone;
    }

    private void tpPLayer()
    {
        if (xPos == -16)
        {
            timerController.StopTimer();
            player.GetComponent<CharacterController>().enabled = true;
            Destroy(spawnedCylinder);
        }
        else
        {
            xPos -= 2;

            Destroy(spawnedCylinder);

            if (cylinderPrefab != null && player != null)
            {
                spawnedCylinder = Instantiate(cylinderPrefab, new Vector3(xPos, 0, 0), Quaternion.identity);
            }
            player.transform.position = spawnedCylinder.transform.position + new Vector3(0.5f, 0, 1.25f);
        }
    }

    public void SetPointsToReceive(int points)
    {
        if (allowedToScore) pointsToReceive = points;
    }
}
