using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckV2 : MonoBehaviour
{
    public bool isColiding;
    CircleCollider2D cc;

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "MazeMap")
        {
            isColiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "MazeMap")
        {
            isColiding = false;
        }
    }
}
