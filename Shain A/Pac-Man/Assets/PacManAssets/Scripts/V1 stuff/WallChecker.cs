using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallChecker : MonoBehaviour
{
    public enum Tiletype { illegal, legale };
    public Tiletype[,] grid;
    public float overlapCheckRadius = 1.0f;
    public GameObject debugsquare;
    public int width = 26;
    public int height = 36;
    public bool debugIt = false;
    //public Transform topCorner;
    Vector2 startingGridCord;
    Vector2 currentGridCord;
    public Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        width = map.size.x;
        height = map.size.y;


        //startingGridCord = map.GetTile(new Vector3Int(0, height, 0));
        grid = new Tiletype[width, height];
        currentGridCord = startingGridCord;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Physics2D.OverlapCircle(currentGridCord, overlapCheckRadius))
                {
                    grid[i, j] = Tiletype.illegal;
                    if (debugIt == true)
                        Instantiate(debugsquare, currentGridCord, Quaternion.identity);
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
