using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] Health health;

    private void Awake()
    {
        if (health == null)
            health = GetComponent<Health>();
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-amount);
    }
}
