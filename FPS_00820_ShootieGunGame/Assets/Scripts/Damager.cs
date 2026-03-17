using UnityEngine;

//Damages objects
public class Damager : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    
    public void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damageAmount);
    }

}




public interface IDamageable
{
    public void TakeDamage(int amount);
}