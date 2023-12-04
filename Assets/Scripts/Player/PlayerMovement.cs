using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    
    [HideInInspector] public float lastHorVector;
    [HideInInspector] public float lastVertVector;

    private Rigidbody2D rb;
    private Vector2 direction;
    public Vector2 Direction { get => direction; }

    private Vector2 lastMovedVector;
    public Vector2 LastMovedVector { get => lastMovedVector; }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    private void Update()
    {
        InputMove();
    }
    
    private void FixedUpdate() => Move();
    private void InputMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction=new Vector2 (moveX, moveY).normalized;

        if (Direction.x != 0)
        {
            lastHorVector = direction.x;
            lastMovedVector = new Vector2(lastHorVector, 0f);
        }
        if (Direction.y != 0)
        {
            lastVertVector = direction.y;
            lastMovedVector = new Vector2(0f, lastVertVector);
        }
        if (direction.x != 0 && direction.y != 0) { lastMovedVector = new Vector2(lastHorVector, lastVertVector); }
    }

    private void Move() => rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

}
