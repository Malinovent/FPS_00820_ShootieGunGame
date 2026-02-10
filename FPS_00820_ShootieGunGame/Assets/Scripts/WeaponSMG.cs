using UnityEngine;

public class WeaponSMG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;
    
    [Header("Rate of Fire")]
    [SerializeField] private float roundsPerSecond = 1f;

    private float timeBetweenShots;
    private float fireTimer;
    private bool canFire = true;
    private bool isFiring = false;

    public bool CanFire => canFire;

    #region OVERRIDES
    private void Awake()
    {
        timeBetweenShots = 1f / roundsPerSecond;
    }

    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
        UpdateFire(Time.deltaTime);

        if(CanFire && isFiring && !ammo.IsReloading)
        {
            ammo.FireShot();
            raycaster.FireShot();
            canFire = false;
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
        canFire = false;
        ammo.StartReload();
    }
    #endregion

    #region RATE OF FIRE

    public void UpdateFire(float deltaTime)
    {
        if (CanFire)
            return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= timeBetweenShots)
        {
            canFire = true;
        }
    }

    #endregion
}
