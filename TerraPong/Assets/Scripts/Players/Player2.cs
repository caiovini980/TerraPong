using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible to handle the player 1's movement
/// </summary>

public class Player2 : PlayerMovement
{
    private float limit = 4.2f;
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //Get inputs and move the player
    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            if (transform.position.y >= limit)
            {
                transform.position = new Vector3(transform.position.x, limit, transform.position.z);
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
            if (transform.position.y <= -limit)
            {
                transform.position = new Vector3(transform.position.x, -limit, transform.position.z);
            }
        }

        else
        {
            return;
        }
    }
}
