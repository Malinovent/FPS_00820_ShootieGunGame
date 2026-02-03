using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponBase[] weapons;

    private int weaponIndex = 0;

    private WeaponBase CurrentWeapon => weapons[weaponIndex];

    /*public WeaponBase CurrentWeapon()
    {
        return weapons[0];
    }*/

    public void OnFire()
    {
        CurrentWeapon.OnFire();
    }
}
