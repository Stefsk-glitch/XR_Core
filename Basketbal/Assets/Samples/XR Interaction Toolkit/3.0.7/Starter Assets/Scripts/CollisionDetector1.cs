using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector1 : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.name.Contains("basketball"))
            scoreManager.SetPointsToReceive(3);
        
        //scoreManager.setText(other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("basketball"))
            scoreManager.SetPointsToReceive(2);

        //scoreManager.setText(other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.Contains("basketball"))
            scoreManager.SetPointsToReceive(2);

        //scoreManager.setText(other.gameObject.name);
    }
}