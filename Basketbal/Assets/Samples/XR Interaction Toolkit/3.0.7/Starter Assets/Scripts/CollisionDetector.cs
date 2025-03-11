using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerExit(Collider other)
    {
        scoreManager.IncreaseScore();
    }
}