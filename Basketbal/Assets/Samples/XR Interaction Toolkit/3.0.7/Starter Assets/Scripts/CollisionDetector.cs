using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerExit(Collider other)
    {
        scoreManager.IncreaseScore();
    }
}