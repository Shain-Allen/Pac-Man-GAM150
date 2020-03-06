using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{

    public float moveSpeed = 1;
    public float deadzone = 0.1f;
    public Animator anim;
    int moveX = 0;
    int moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < -deadzone)
        {
            transform.position -= new Vector3(0.2f,0,0);
            moveX = -1;
            moveY = 0;
        }

        if (Input.GetAxis("Horizontal") >= deadzone)
        {
            transform.position += new Vector3(0.2f, 0, 0);
            moveX = 1;
            moveY = 0;
        }

        if (Input.GetAxis("Vertical") >= deadzone)
        {
            transform.position += new Vector3(0, 0.2f, 0);
            moveY = 1;
            moveX = 0;
        }

        if (Input.GetAxis("Vertical") < -deadzone)
        {
            transform.position -= new Vector3(0, 0.2f, 0);
            moveY = -1;
            moveX = 0;
        }
        anim.SetFloat("MoveX", moveX);
        anim.SetFloat("MoveY", moveY);
    }
}
