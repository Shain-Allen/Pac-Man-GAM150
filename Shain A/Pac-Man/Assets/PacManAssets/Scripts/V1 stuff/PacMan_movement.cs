using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan_movement : MonoBehaviour
{
    public WallChecker walls;
    public Transform tForm;
    public float deadzone = 0.1f;
    public float waitTime = 1f;

    public int startingRow = 17;
    public int startingColumb = 14;

    int currentRow;
    int currentColumb;

    int nextRow;
    int nextColumb;

    float timebetweenmovement;

    public enum moveDir {UP, DOWN, RIGHT, LEFT };
    public moveDir moveDirection = moveDir.LEFT;

    // Start is called before the first frame update
    void Start()
    {
        timebetweenmovement = waitTime;
        //currentRow = startingRow;
        //currentColumb = startingColumb;

        currentRow = (int)Mathf.Round(tForm.position.y + (walls.height / 2));
        currentColumb = (int)Mathf.Round(tForm.position.x + (walls.width / 2));

        tForm.position = new Vector2(0.5f, tForm.position.y);

        switch (moveDirection)
        {
            case moveDir.UP:
                nextRow = currentRow + 1;
                nextColumb = currentColumb;
                break;
            case moveDir.DOWN:
                nextRow = currentRow - 1;
                nextColumb = currentColumb;
                break;
            case moveDir.RIGHT:
                nextColumb = currentColumb + 1;
                nextRow = currentRow;
                break;
            case moveDir.LEFT:
                nextColumb = currentColumb - 1;
                nextRow = currentRow;
                break;
        }

        //Debug.Log(walls.grid[nextRow, nextColumb]);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(walls.grid[currentRow, currentColumb]);

        if (Input.GetAxis("Horizontal") <= -deadzone)
        {
            moveDirection = moveDir.LEFT;
        }
        
        if (Input.GetAxis("Horizontal") >= deadzone)
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
        timebetweenmovement -= Time.deltaTime;

        if (timebetweenmovement <= 0f)
        {
            Movement();
            timebetweenmovement = waitTime;
        }
    }

    private void Movement()
    {
        Vector2 pos = new Vector2(tForm.position.x, tForm.position.y);

        switch (moveDirection)
        {
            case moveDir.UP:
                Debug.Log(walls.grid[nextRow, currentColumb]);
                if (walls.grid[nextRow, currentColumb] == WallChecker.Tiletype.legale)
                {
                    pos.y += 1f;
                    currentRow += 1;
                    nextRow += 1;
                    nextColumb = currentColumb;
                }

                break;
            case moveDir.DOWN:
                Debug.Log(walls.grid[nextRow, currentColumb]);
                if (walls.grid[nextRow, currentColumb] == WallChecker.Tiletype.legale)
                {
                    pos.y -= 1f;
                    currentRow -= 1;
                    nextRow -= 1;
                    nextColumb = currentColumb;
                }

                break;
            case moveDir.RIGHT:
                Debug.Log(walls.grid[currentRow, nextColumb]);
                if (walls.grid[currentRow, nextColumb] == WallChecker.Tiletype.legale)
                {
                    pos.x += 1f;
                    currentColumb += 1;
                    nextColumb += 1;
                    nextRow = currentRow;
                }

                break;
            case moveDir.LEFT:
                Debug.Log(walls.grid[currentRow, nextColumb]);
                if (walls.grid[currentRow, nextColumb] == WallChecker.Tiletype.legale)
                {
                    pos.x -= 1f;
                    currentColumb -= 1;
                    nextColumb -= 1;
                    nextRow = currentRow;
                }

                break;
        }

        tForm.position = pos;
    }
}
