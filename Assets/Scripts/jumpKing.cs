using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class jumpKing : MonoBehaviour
{
    public float walkSpeed;
    public float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    public float jumpValueCounter;
    public float MaxJumpValue = 20;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVector = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        if (jumpValue < 0.1f && isGrounded)
        {
            print("Am i running?");
            rb.velocity = moveVector;
        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        if(jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            jumpValue += jumpValueCounter * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            print("Nothing2");
        }

        if(jumpValue >= MaxJumpValue && isGrounded)
        {
            print("Nothing?");
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        
        if (isGrounded)
        {
            canJump = true;
        }
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                print("Nothing 3");
                jumpValue = 0.0f;
            }
        }
    }

    void ResetJump()
    {
        //canJump = false;
        jumpValue = 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }
}
*/