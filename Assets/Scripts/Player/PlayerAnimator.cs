using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerMovement.Direction.x != 0 || playerMovement.Direction.y != 0)
        {
            animator.SetBool("IsMoving", true);
            CheckSpriteDirection();
        }
        else
            animator.SetBool("IsMoving", false);
    }

    void CheckSpriteDirection() => spriteRenderer.flipX = (playerMovement.lastHorVector < 0) ? true : false;
}
