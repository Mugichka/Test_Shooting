using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public sealed class BulletPool
{
    private Queue<GameObject> pool;
    private GameObject bulletPrefab;
    private Transform parent;

    public BulletPool(GameObject prefab, int size,Transform poolParent)
    {
        bulletPrefab = prefab;
        parent = poolParent;
        pool = new Queue<GameObject>();
        InitializePool(size);
    }

    private void InitializePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, parent);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = pool.Dequeue();
        bullet.SetActive(true);
        pool.Enqueue(bullet);
        return bullet;
    }
}