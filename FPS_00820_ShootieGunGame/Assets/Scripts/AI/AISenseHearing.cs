using System;
using Unity.VisualScripting;
using UnityEngine;

public class AISenseHearing : MonoBehaviour
{
    [SerializeField] private float hearingRange = 10f;
    [SerializeField] private LayerMask validLayers;

    public event Action<Transform> onPlayerHeard;

    public void UpdateHearing()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hearingRange, validLayers);

        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Player"))
            {
                onPlayerHeard?.Invoke(collider.transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hearingRange);
    }

}
