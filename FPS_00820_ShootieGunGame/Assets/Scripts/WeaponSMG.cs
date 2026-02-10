using UnityEngine;

public class WeaponSMG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;

    private bool isFiring = false;

    #region OVERRIDES
    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
        

        if(isFiring && !ammo.IsReloading)
        {
            ammo.FireShot();
            raycaster.FireShot();
            
        }
    }

    public override void OnFirePressed()
    {
        isFiring = true;
    }

    public override void OnFireReleased()
    {
        isFiring = false;
    }

    public override void OnReload()
    {        
        ammo.StartReload();
    }
    #endregion

}
