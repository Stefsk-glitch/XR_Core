using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BasketballSpawner : MonoBehaviour
{
    public GameObject basketballPrefab;
    public XRDirectInteractor rightHand;
    public XRDirectInteractor leftHand;
    public Transform rightHandSpawnPoint;
    public Transform leftHandSpawnPoint;
    public float handYThreshold = 0.5f;
    public float spawnDelay = 1f; 

    private bool canSpawn = true;

    void Update()
    {
        // Check if the right controller is below the threshold
        bool handsAreDown = rightHand.transform.position.y < handYThreshold &&
                            leftHand.transform.position.y < handYThreshold;

        // Check if hands are empty
        bool handsAreEmpty = !rightHand.hasSelection && !leftHand.hasSelection;

        if (handsAreDown && handsAreEmpty && canSpawn)
        {
            SpawnBasketball();
            StartCoroutine(SpawnCooldown());
        }
    }

    void SpawnBasketball()
    {
        // Choose the right hand first, or left if right is occupied
        Transform spawnPoint = rightHandSpawnPoint ? rightHandSpawnPoint : leftHandSpawnPoint;
        XRDirectInteractor targetHand = !rightHand.hasSelection ? rightHand : leftHand;

        if (spawnPoint == null || targetHand == null) return;

        // Instantiate the basketball
        GameObject newBall = Instantiate(basketballPrefab, spawnPoint.position, spawnPoint.rotation);
        XRGrabInteractable grabInteractable = newBall.GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Ensure the ball is grabbed automatically
            IXRSelectInteractor handInteractor = (IXRSelectInteractor)targetHand;
            IXRSelectInteractable ballInteractable = (IXRSelectInteractable)grabInteractable;

            targetHand.interactionManager.SelectEnter(handInteractor, ballInteractable);
        }
    }

    IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }
}
