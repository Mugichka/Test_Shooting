using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMarker : MonoBehaviour,IDamageable
{
    [SerializeField]private float health = 100f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
