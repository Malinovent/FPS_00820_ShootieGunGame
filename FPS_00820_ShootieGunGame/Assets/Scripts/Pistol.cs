using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;

    private void OnEnable()
    {
        SendWeaponInfo();
        ammo.OnReload += SendWeaponInfo;
    }

    private void OnDisable()
    {
        ammo.OnReload -= SendWeaponInfo;
    }

    public override void UpdateWeapon()
    {
        //Update reload timer
        ammo.UpdateReload(Time.deltaTime);
    }

    public override void OnFirePressed()
    {
        //If we have ammo and we are not reloading
        //Fire a shot
        if(ammo.HasAmmo() && !ammo.IsReloading)
        {
            ammo.FireShot();
            raycaster.FireShot();
            SendWeaponInfo();
        }
    }

    public override void OnFireReleased()
    {
        
    }

    public override void OnReload()
    {
        ammo.StartReload();
        SendWeaponInfo();
    }

    private void SendWeaponInfo()
    {
        WeaponInfo info = new WeaponInfo(weaponName, "__\n" + ammo.MaxAmmo.ToString(), ammo.RemainingAmmo.ToString(), ammo.RemainingMagazine.ToString());
        //onWeaponUpdated?.Invoke(info);
    }
}
