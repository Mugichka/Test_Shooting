using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;



public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Transform firePoint;
    // [SerializeField] protected Transform firePoint;
    // [SerializeField] protected GameObject bulletPrefab;
    // [SerializeField] protected int poolSize = 20;
    // [SerializeField] protected float reloadTime = 2f;
    // [SerializeField] protected float shootDelay = 0.5f;
    // [SerializeField] protected int maxAmmo = 10;


    protected BulletPool bulletPool;
    protected bool isReloading = false;
    protected bool canShoot = true;
    protected int currentAmmo;
    protected float lastShootTime;
    private CancellationTokenSource reloadCts;

    public bool CanShoot => canShoot && !isReloading && currentAmmo > 0;
    public bool IsReloading => isReloading;
    public int CurrentAmmo => currentAmmo;
    public int MaxAmmo => weaponData.MaxAmmo;

    protected virtual void Start()
    {
        var bulletRoot = new GameObject("BulletPool");
        bulletPool = new BulletPool(weaponData.BulletPrefab, weaponData.PoolSize, bulletRoot.transform);
        currentAmmo = MaxAmmo;
        GameEvents.OnWeaponLoaded?.Invoke();
    }

    public async UniTask Reload(CancellationToken token)
    {
        if (!isReloading && currentAmmo < MaxAmmo)
        {
            reloadCts = new CancellationTokenSource();
            isReloading = true;
            try
            {
                await UniTask.Delay(System.TimeSpan.FromSeconds(weaponData.ReloadTime), cancellationToken: token);
                currentAmmo = MaxAmmo;
            }
            catch (OperationCanceledException) { }
            finally
            {
                isReloading = false;
                GameEvents.OnReloadFinish?.Invoke();
                reloadCts.Dispose();
            }
        }
    }

    public abstract void Shoot();
}
