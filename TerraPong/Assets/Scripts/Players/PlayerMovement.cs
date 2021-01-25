using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SuperClass to example inheritance with player's speed
/// </summary>

public class PlayerMovement : MonoBehaviour
{   
    public float speed;

    public PlayerMovement()
    {
        speed = 5f;
    }
}
