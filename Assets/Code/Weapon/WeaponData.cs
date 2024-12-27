using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponData), menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject
{
   
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private int maxAmmo = 10;

    
    public GameObject BulletPrefab { get => bulletPrefab; }
    public int PoolSize { get => poolSize;  }
    public float ReloadTime { get => reloadTime;  }
    public float ShootDelay { get => shootDelay; }
    public int MaxAmmo { get => maxAmmo; }
}
