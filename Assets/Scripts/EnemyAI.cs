using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    [SerializeField] private Health health;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float offset = 2f;
    [SerializeField] private float chanceToChangeDirection = .1f;

    private bool isIdle = false;
    private int direction = 1;


    [SerializeField] private float minChanceToDrop = 3f;
    [SerializeField] private float maxChanceToDrop = 5f;
    [SerializeField] private GameObject boxPrefab;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 startPosition;


    private void Start()
    {
        if (health == null)
            health = GetComponent<Health>();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;

        StartCoroutine(RandomDropCoroutine(minChanceToDrop, maxChanceToDrop));
    }

    private void Update()
    {
        if (health.CheckIsAlive())
        {
            Movement();
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (Random.value < chanceToChangeDirection)
        {
            direction *= -1;
        }
    }

    private void DropBox()
    {
        GameObject box = Instantiate(boxPrefab);
        box.transform.position = transform.position;
    }

    private void Movement()
    {
        Vector3 locScl = transform.localScale;
        GameUtilities.ScaleFlip(direction, ref locScl);
        transform.localScale = locScl;

        rb.velocity = transform.right * speed * direction;

        UpdateAnimation();

        if (transform.position.x < startPosition.x - offset)
        {
            direction = 1;
        }
        else if (transform.position.x > startPosition.x + offset)
        {
            direction = -1;
        }
    }

    private void UpdateAnimation()
    {
        if (isIdle)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    private IEnumerator RandomDropCoroutine(float minTime, float maxTime)
    {
        while (true)
        {
            if (health.CheckIsAlive())
            {
                yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

                isIdle = true;

                animator.SetTrigger("PickUp");

                yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"));

                DropBox();

                isIdle = false;
            }
            else
            {
                animator.SetTrigger("isDead");
                break;
            }
        }

    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-amount);
    }
}
