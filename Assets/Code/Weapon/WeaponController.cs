using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI reloadText;


    private WeaponSelector weaponSelector;
    private WeaponUI weaponUI;
    private WeaponActions weaponActions;

    private void OnEnable()
    {
        GameEvents.OnShoot += UpdateUI;
        GameEvents.OnReloadStart += UpdateUI;
        GameEvents.OnReloadFinish += UpdateUI;
        GameEvents.OnWeaponLoaded += UpdateUI;
        GameEvents.OnWeaponSwap += UpdateUI;
    }

    void OnDisable()
    {
        GameEvents.OnShoot -= UpdateUI;
        GameEvents.OnReloadStart -= UpdateUI;
        GameEvents.OnReloadFinish -= UpdateUI;
        GameEvents.OnWeaponLoaded -= UpdateUI;
        GameEvents.OnWeaponSwap -= UpdateUI;
    }

    void Start()
    {
        weaponSelector = new WeaponSelector(weapons);
        weaponUI = new WeaponUI(ammoText, reloadText);
        weaponActions = new WeaponActions(weaponSelector);
        UpdateUI();
    }

    void Awake()
    {

    }

    void Update()
    {
        weaponSelector.Run();
        weaponActions.Run();
    }


    private void UpdateUI()
    {
        weaponUI.UpdateUI(weaponSelector.CurrentWeapon.CurrentAmmo.ToString(), weaponSelector.CurrentWeapon.MaxAmmo.ToString(), weaponSelector.CurrentWeapon.IsReloading);
    }


}
