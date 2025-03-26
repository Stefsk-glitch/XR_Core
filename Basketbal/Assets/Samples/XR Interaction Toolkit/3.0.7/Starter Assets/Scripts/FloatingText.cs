using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform worldSpaceCanvas;

    public float distanceFromPlayer = 2.0f;     // offset from player
    public float verticalOffset = 0f;

    void Start()
    {
        mainCam = Camera.main.transform;

        worldSpaceCanvas = GameObject.Find("Score Canvas").transform;
        transform.SetParent(worldSpaceCanvas);
    }

    void Update()
    {
        Vector3 forwardOffset = mainCam.forward * distanceFromPlayer;
        Vector3 verticalOffsetVector = Vector3.up * verticalOffset;
        transform.position = mainCam.position + forwardOffset + verticalOffsetVector;

        Vector3 cameraForward = mainCam.forward;
        cameraForward.y = 0;                    // keeps text upright
        Quaternion lookRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = lookRotation;
    }
}
