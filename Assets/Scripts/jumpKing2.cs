using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpKing2 : MonoBehaviour
{
    public float walkSpeed;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;
    public float jumpValueCounter = 10f;
    public float maxJumpValue = 10;

    [Header("MaxValues")] public float maxVelocity;
    
    private Dash _dash;
    private Input input;

    private float timerTime;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        input = GetComponent<Input>();
        _dash = GetComponent<Dash>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.1f),
            new Vector2(0.9f, 0.4f), 0f, groundMask);
        
        if (_dash._isDashing) return;
        
        if (isGrounded && !canJump)
        {
            canJump = true;
        }

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(input.MoveInput.x * walkSpeed, rb.velocity.y);
        }
        
        rb.sharedMaterial = jumpValue > 0 ? bounceMat : normalMat;

        if(input.JumpHeld && isGrounded && canJump)
        {
            jumpValue += jumpValueCounter * Time.deltaTime;
        }

        if(input.JumpPressed && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if(jumpValue >= maxJumpValue && isGrounded)
        {
            float tempx = input.MoveInput.x * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        
        if(input.JumpReleased)
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(input.MoveInput.x * walkSpeed, jumpValue);
                canJump = true;
                jumpValue = 0;
            }
        }

        var rbVelocity = rb.velocity;
        rbVelocity.y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            //CinemachineShake.Instance.ShakeCamera(Mathf.Abs(rb.velocity.magnitude * 0.5f), 0.3f);
        }
    }
}