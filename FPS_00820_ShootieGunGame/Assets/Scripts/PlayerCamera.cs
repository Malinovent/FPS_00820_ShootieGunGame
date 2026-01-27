using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float minPitch = -30;
    [SerializeField] private float maxPitch = 60;

    private float currentPitch = 0;
    
    public void Rotate(float inputY)
    {
        currentPitch -= inputY;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        cameraTransform.localEulerAngles = new Vector3(currentPitch, 0, 0);
    }
}
