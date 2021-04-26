using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        CheckIsAlive();
    }

    public bool CheckIsAlive()
    {
        if (currentHealth > 0)
            isAlive = true;
        else
            isAlive = false;

        return isAlive;
    }

}
