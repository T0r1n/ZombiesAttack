using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public void turnLeft()
    {
        rb.rotation = 90f;
    }

    public void turnUp()
    {
        rb.rotation = 0f;
    }

    public void turnRight()
    {
        rb.rotation = -90f;
    }
}
