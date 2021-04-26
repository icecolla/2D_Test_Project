using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Health health;

    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private AnimationCurve playerSpeed;

    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;

    private bool isGrounded = false;


    private void Awake()
    {
        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();
        if (health == null)
            health = GetComponent<Health>();

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health.CheckIsAlive())
        {
            OnGroundCheck();

            UpdateAnimation(playerInput.Direction);
            Jump();
            Move(playerInput.Direction);
        }
        else
        {
            playerAnimator.SetTrigger("isDead");
        }

    }

    private void UpdateAnimation(float direction)
    {
        if (Mathf.Abs(direction) > Mathf.Epsilon)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    private void OnGroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (isGrounded && playerInput.Jump)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }

    public void Move(float direction)
    {
        Vector3 locRot = transform.localEulerAngles;
        GameUtilities.RotationFlip(direction, ref locRot);
        transform.localEulerAngles = locRot;

        playerRigidbody.velocity = new Vector2(playerSpeed.Evaluate(direction), playerRigidbody.velocity.y);
    }
}
