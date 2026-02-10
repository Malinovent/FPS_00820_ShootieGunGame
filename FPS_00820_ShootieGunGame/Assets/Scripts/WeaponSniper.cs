using UnityEngine;

public class WeaponSniper : WeaponBase
{
    [SerializeField] Ammo ammo;
    [SerializeField] Raycaster raycaster;
    [SerializeField] RateOfFire RoF;

    public override void UpdateWeapon()
    {
        //Update reload timer
        RoF.UpdateFire(Time.deltaTime);
        ammo.UpdateReload(Time.deltaTime);
    }

    public override void OnFirePressed()
    {
        //If we have ammo and we are not reloading
        //Fire a shot
        if (RoF.CanFire && ammo.HasAmmo() && !ammo.IsReloading)
        {
            ammo.FireShot();
            raycaster.FireShot();
            RoF.FireShot();
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