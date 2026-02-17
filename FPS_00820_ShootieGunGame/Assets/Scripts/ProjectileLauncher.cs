using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    public void SpawnProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(transform.forward));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(firePoint.position, firePoint.position + (transform.forward * 50));

    }
}