using UnityEngine;

public class WeaponRPG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private ProjectileLauncher launcher;

    public override void OnFirePressed()
    {
        if(ammo.HasAmmo() && !ammo.IsReloading)
        {
            FireShot();
        }
    }
    
    private void FireShot()
    {
        ammo.FireShot();
        ammo.StartReload();
        launcher.SpawnProjectile();
    }

    public override void OnFireReleased()
    {

    }

    public override void OnReload()
    {
        
    }

    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
    }
}
