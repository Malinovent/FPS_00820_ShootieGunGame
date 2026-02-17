using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Raycaster raycaster;

    public void SpawnProjectile()
    {
        RaycastHit hit = raycaster.FireShot();
        Vector3 direction = hit.point - firePoint.position;

        if(hit.point == Vector3.zero)
        {
            direction = transform.forward;
        }

        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        RaycastHit hit = raycaster.FireShot();

        if (hit.point == Vector3.zero)
        {
            Gizmos.DrawLine(firePoint.position, firePoint.position + (transform.forward * 50));
        }
        else
        {
            Gizmos.DrawLine(firePoint.position, hit.point);
        }

        

    }
}