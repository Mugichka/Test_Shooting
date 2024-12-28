using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public sealed class WeaponActions
{
    private CancellationTokenSource reloadCts;
    private WeaponSelector weaponSelector;

    public WeaponActions(WeaponSelector weaponSelector)
    {
        this.weaponSelector = weaponSelector;
    }
    public void Run()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        reloadCts?.Cancel();
        reloadCts = new CancellationTokenSource();
        weaponSelector.CurrentWeapon.Reload(reloadCts.Token).Forget();
    }
    private void Shoot()
    {
        weaponSelector.CurrentWeapon.Shoot();
    }
}
