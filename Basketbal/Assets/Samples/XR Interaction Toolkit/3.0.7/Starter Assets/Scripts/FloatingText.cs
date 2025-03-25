using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform worldSpaceCanvas;

    public float distanceFromPlayer = 2.0f;

    void Start()
    {
        mainCam = Camera.main.transform;

        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;
        transform.SetParent(worldSpaceCanvas);
    }

    void Update()
    {
        Vector3 forwardOffset = mainCam.forward * distanceFromPlayer;
        transform.position = mainCam.position + forwardOffset;

        Vector3 cameraForward = mainCam.forward;
        cameraForward.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = lookRotation;
    }
}
