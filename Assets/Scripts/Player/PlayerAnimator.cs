using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerMovement.Direction.x != 0 || playerMovement.Direction.y != 0)
        {
            animator.SetBool("IsMoving", true);
            CheckSpriteDirection();
        }
        else
            animator.SetBool("IsMoving", false);
    }

    private void CheckSpriteDirection() => spriteRenderer.flipX = (playerMovement.lastHorVector < 0) ? true : false;
}
