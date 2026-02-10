using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;

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
        }
    }

    public override void OnFireReleased()
    {
        
    }

    public override void OnReload()
    {
        ammo.StartReload();
    }
}
