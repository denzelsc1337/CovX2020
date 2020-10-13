using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float runspeed = 10;
    public float jumpspeed = 15;
    private Rigidbody2D rb2D;



    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runspeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("space") && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
        }
    }

    public void irDerecha()
    {
        rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
    }

    public void irIzquierda()
    {
        Debug.Log("okis");
    }
}
