using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDots : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PacmanStats>().numberOfDots += 1;

            Destroy(gameObject);
        }
    }
}
