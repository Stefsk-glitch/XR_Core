using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector1 : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerExit(Collider other)
    {
        scoreManager.GivePoints(3);
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.GivePoints(2);
    }

    private void OnTriggerStay(Collider other)
    {
        scoreManager.GivePoints(2);
    }
}