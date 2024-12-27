using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public sealed class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    private CancellationTokenSource reloadCts;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadCts?.Cancel();
            reloadCts = new CancellationTokenSource();
            currentWeapon.Reload(reloadCts.Token).Forget();
        }
    }
}
