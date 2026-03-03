using UnityEngine;
using TMPro;

//It will observer
//1 - When we switch weapons
//2 - After shooting
//3 - After reloading
public class UIWeaponManager : MonoBehaviour
{
    [SerializeField] private TMP_Text weaponName;
    [SerializeField] private TMP_Text ammoRemaining;
    [SerializeField] private TMP_Text ammoMax;
    [SerializeField] private TMP_Text magazinesRemaining;

    private void OnEnable()
    {
        WeaponBase.onWeaponUpdated += OnWeaponUpdated;

    }

    private void OnDisable()
    {
        WeaponBase.onWeaponUpdated -= OnWeaponUpdated;
    }

    private void OnWeaponUpdated(WeaponInfo info)
    {
        this.weaponName.SetText(info.weaponName);
        this.ammoMax.SetText(info.ammoMax);
        this.ammoRemaining.SetText(info.ammoRemaining);
        this.magazinesRemaining.SetText(info.magazineRemaining);
    }

    public void UpdateWeaponUI(string weaponName, string ammoRemaining, string ammoMax, string magazinesRemaining)
    {
        this.weaponName.SetText(weaponName);
        this.ammoMax.SetText(ammoRemaining);
        this.ammoRemaining.SetText(ammoMax);
        this.magazinesRemaining.SetText(magazinesRemaining);
    }
}
