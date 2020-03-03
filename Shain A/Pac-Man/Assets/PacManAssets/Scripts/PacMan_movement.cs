using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan_movement : MonoBehaviour
{
    public WallChecker walls;
    public Transform tForm;
    public float deadzone = 0.1f;


    int startingRow = 17;
    int startingColumb = 14;

    int currentRow;
    int currentColumb;

    int nextRow;
    int nextColumb;

    public enum moveDir {UP, DOWN, RIGHT, LEFT };
    public moveDir moveDirection = moveDir.LEFT;

    // Start is called before the first frame update
    void Start()
    {
        currentRow = startingRow;
        currentColumb = startingColumb;

        tForm.position = new Vector2(0.5f, tForm.position.y);

        switch (moveDirection)
        {
            case moveDir.UP:
                nextRow = currentRow - 1;
                break;
            case moveDir.DOWN:
                nextRow = currentRow + 1;
                break;
            case moveDir.RIGHT:
                nextColumb = currentColumb - 1;
                break;
            case moveDir.LEFT:
                nextColumb = currentColumb + 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") >= deadzone)
        {
            moveDirection = moveDir.LEFT;
        }
        
        if (Input.GetAxis("Horizontal") <= -deadzone)
        {
            moveDirection = moveDir.RIGHT;
        }

        if (Input.GetAxis("Vertical") >= deadzone)
        {
            moveDirection = moveDir.UP;
        }

        if (Input.GetAxis("Vertical") <= -deadzone)
        {
            moveDirection = moveDir.DOWN;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = new Vector2(tForm.position.x, tForm.position.y);

        switch (moveDirection)
        {
            case moveDir.UP:

                

                break;
            case moveDir.DOWN:



                break;
            case moveDir.RIGHT:



                break;
            case moveDir.LEFT:



                break;
        }
    }
}
