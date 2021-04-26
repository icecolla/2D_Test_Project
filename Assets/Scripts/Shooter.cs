using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    [SerializeField] private GameObject bullet;
    [SerializeField] Animator animator;

    private void Awake()
    {
        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.Fire)
        {
            Shoot(transform);
        }
    }

    public void Shoot(Transform origin)
    {
        animator.SetTrigger("isShooting");

        Projectile projectile = Instantiate(bullet, origin.position, origin.rotation).GetComponent<Projectile>();

        projectile.Launch();
    }
}
