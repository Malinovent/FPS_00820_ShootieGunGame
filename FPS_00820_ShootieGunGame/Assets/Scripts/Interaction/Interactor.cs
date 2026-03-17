using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Raycaster raycaster;
    [SerializeField] private float raycastDistance = 4;

    public void Interact()
    {
        RaycastHit hitObject = raycaster.FireShot(raycastDistance);

        IInteractable interactable = hitObject.collider.GetComponent<IInteractable>();
        interactable?.Interact();
    }
    
}
