using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pistol : Weapon
{
    public override void Shoot()
    {
        
        if (CanShoot && Time.time >= lastShootTime + weaponData.ShootDelay)
        {
            lastShootTime = Time.time;
            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Bullet>().Initialize(Vector3.forward);
            currentAmmo--;
            GameEvents.OnShoot?.Invoke();
        }
    }

}
