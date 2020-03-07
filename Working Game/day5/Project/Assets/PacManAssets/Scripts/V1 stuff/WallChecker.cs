using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallChecker : MonoBehaviour
{
    public enum Tiletype { illegal, legale, NPELLET, PPELLET };
    public Tiletype[,] grid;
    public float overlapCheckRadius = 1.0f;
    public GameObject debugsquare;
    public int width = 26;
    public int height = 36;
    public bool debugIt = false;
    public Transform topCorner;
    public GameObject nPellet;
    public GameObject pPellet;
    Vector2 startingGridCord;
    Vector2 currentGridCord;
    

    // Start is called before the first frame update
    void Start()
    {
        startingGridCord = topCorner.position;
        grid = new Tiletype[width, height];
        currentGridCord = startingGridCord;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Physics2D.OverlapCircle(currentGridCord, overlapCheckRadius, LayerMask.GetMask("Map")))
                {
                    grid[i, j] = Tiletype.illegal;
                    if (debugIt == true)
                        Instantiate(debugsquare, currentGridCord, Quaternion.identity);
                }
                else if (Physics2D.OverlapCircle(currentGridCord, overlapCheckRadius, LayerMask.GetMask("Pellets")))
                {
                    grid[i, j] = Tiletype.NPELLET;
                    Instantiate(nPellet, currentGridCord, Quaternion.identity);
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
}
