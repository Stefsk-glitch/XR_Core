using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TurnOffBounce : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public Transform playerTransform;
    private Collider objectCollider;

    public PhysicsMaterial bouncyMaterial;
    public PhysicsMaterial nonBouncyMaterial;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<Collider>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            float distance = Vector3.Distance(playerTransform.position, grabInteractable.transform.position);

            if (distance > 4)
            {

                if (grabInteractable.isSelected)
                {
                    var oldestInteractor = grabInteractable.GetOldestInteractorSelecting();

                    if (oldestInteractor != null)
                    {
                        // Force detach
                        grabInteractable.interactionManager.SelectExit(oldestInteractor, grabInteractable);
                    }
                }
            }
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        objectCollider.material = nonBouncyMaterial;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        objectCollider.material = bouncyMaterial;
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
