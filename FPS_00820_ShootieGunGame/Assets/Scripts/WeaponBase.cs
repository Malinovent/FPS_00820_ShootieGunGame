using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public string weaponName;

    public abstract void OnFire();
    public abstract void OnReload();
}
