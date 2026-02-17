using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float explosionRadius = 5;

    public void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == false)
        {
            Explode();
        }
    }

    private void Explode()
    {

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);

        foreach(Collider col in colliders)
        {
            Debug.Log($"Exploded {col.gameObject.name}");
        }


        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
