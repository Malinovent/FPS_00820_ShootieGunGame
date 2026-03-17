using UnityEngine;

public class Dummy : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        Debug.Log("Dummy animation!");
    }
}
