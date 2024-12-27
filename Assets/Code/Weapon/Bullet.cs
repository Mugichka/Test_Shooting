using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float lifetime = 3f;
    [SerializeField] protected float damage = 10f;
    protected Vector3 direction;

    public virtual void Initialize(Vector3 dir)
    {
        direction = dir;
        Invoke(nameof(Deactivate), lifetime);
    }

    void Update()
    {
        Run();
    }

    protected virtual void Run()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime))
        {
            OnHit(hit.collider);
        }
    }

    protected virtual void OnHit(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
        Deactivate();
    }

    protected virtual void Deactivate()
    {
        CancelInvoke(nameof(Deactivate));
        gameObject.SetActive(false);
    }
}
