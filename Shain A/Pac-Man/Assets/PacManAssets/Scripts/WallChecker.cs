using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public enum Tiletype { illegal, legale };
    public Tiletype[,] grid;
    public float overlapCheckRadius = 1.0f;
    public GameObject debugsquare;
    public int width = 26;
    public int height = 36;
    Vector2 startingGridCord = new Vector2(-13.5f, 15.5f);
    Vector2 currentGridCord;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Tiletype[width, height];
        currentGridCord = startingGridCord;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Physics2D.OverlapCircle(currentGridCord, overlapCheckRadius))
                {
                    grid[i, j] = Tiletype.illegal;
                    //Instantiate(debugsquare, currentGridCord, Quaternion.identity);
                }
                else
                {
                    grid[i, j] = Tiletype.legale;
                }

                currentGridCord.x += 1.0f;
            }
            currentGridCord.y += -1.0f;
            currentGridCord.x = startingGridCord.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
