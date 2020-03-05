using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovementV2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1;
    public float deadzone = 0.1f;
    public WallCheckV2 wallCheckerTL;
    public WallCheckV2 wallCheckerTR;
    public WallCheckV2 wallCheckerBR;
    public WallCheckV2 wallCheckerBL;

    public enum moveDir { UP, DOWN, RIGHT, LEFT };
    public moveDir moveDirection = moveDir.LEFT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") <= -deadzone)
        {
            if (wallCheckerBL & wallCheckerTL)
                moveDirection = moveDir.LEFT;
        }

        if (Input.GetAxis("Horizontal") >= deadzone)
        {
            if (wallCheckerBR & wallCheckerTR)
                moveDirection = moveDir.RIGHT;
        }

        if (Input.GetAxis("Vertical") >= deadzone)
        {
            if (wallCheckerTR & wallCheckerTL)
                moveDirection = moveDir.UP;
        }

        if (Input.GetAxis("Vertical") <= -deadzone)
        {
            if (wallCheckerBR & wallCheckerBL)
                moveDirection = moveDir.DOWN;
        }
    }

    private void FixedUpdate()
    { 
        Movement();
    }

    private void Movement()
    {
        switch (moveDirection)
        {
            case moveDir.UP:
                
                    rb.MovePosition(rb.transform.position + new Vector3(0f, 1f) * moveSpeed * Time.deltaTime);

                break;
            case moveDir.DOWN:
                
                    rb.MovePosition(rb.transform.position + new Vector3(0f, -1f) * moveSpeed * Time.deltaTime);

                break;
            case moveDir.RIGHT:
                
                    rb.MovePosition(rb.transform.position + new Vector3(1f, 0f) * moveSpeed * Time.deltaTime);

                break;
            case moveDir.LEFT:
                
                    rb.MovePosition(rb.transform.position + new Vector3(-1f, 0f) * moveSpeed * Time.deltaTime);

                break;
        }
    }
}
