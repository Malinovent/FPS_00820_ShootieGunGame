using UnityEngine;
using System;

public abstract class WeaponBase : MonoBehaviour
{
    public static event Action<WeaponInfo> onWeaponUpdated;

    [SerializeField] protected string weaponName = "Pistol";

    public abstract void UpdateWeapon();
    public abstract void OnFirePressed();
    public abstract void OnFireReleased();
    public abstract void OnReload();
}

public struct WeaponInfo
{
    public string weaponName;
    public string ammoMax;
    public string ammoRemaining;
    public string magazineRemaining;

    public WeaponInfo(string weaponName, string ammoMax, string ammoRemaining, string magazineRemaining)
    {
        this.weaponName = weaponName;
        this.ammoMax = ammoMax;
        this.ammoRemaining = ammoRemaining;
        this.magazineRemaining = magazineRemaining;
    }
}