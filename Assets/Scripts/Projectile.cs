using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D projectileRb;

    [SerializeField] private int damage;
    [SerializeField] private float speed = 1f;


    private void Awake()
    {
        if (projectileRb == null)
            projectileRb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MonoBehaviour>(out var mb))
        {
            if (mb is IDamageable damageable)
            {
                damageable.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

    public void Launch()
    {
        projectileRb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
}
