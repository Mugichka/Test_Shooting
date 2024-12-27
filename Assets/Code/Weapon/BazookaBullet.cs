using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BazookaBullet : Bullet
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;
    [SerializeField] private float bulletSize;

    protected override void OnHit(Collider other)
    {
         Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in colliders)
        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Deactivate();
    }

    protected override void Run()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        var collider= Physics.OverlapSphere(transform.position, bulletSize);
        foreach (var hitCollider in collider)
        {
            if (hitCollider == null)
            {
                continue;
            }
            OnHit(hitCollider);
            break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bulletSize);
    }
}
