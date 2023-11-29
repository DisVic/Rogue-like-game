using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]float moveSpeed;
    
    [HideInInspector]public float lastHorVector;
    [HideInInspector]public float lastVertVector;

    Rigidbody2D rb;
    Vector2 direction;
    public Vector2 Direction { get { return direction; } }  
    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update() => InputMove();
    
    private void FixedUpdate() => Move();
    private void InputMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction=new Vector2 (moveX, moveY).normalized;

        if(Direction.x!=0) lastHorVector = direction.x;
        if (Direction.y != 0) lastVertVector = direction.y;
    }

    private void Move() => rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

}
