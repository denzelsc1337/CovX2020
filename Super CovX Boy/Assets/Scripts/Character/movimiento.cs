using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movimiento : MonoBehaviour
{
    public float runspeed = 10;
    public float jumpspeed = 15;
    private Rigidbody2D rb2D;
    public float conteo = 0.0f;
    private Button Izquierdass, Derechass;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moving();
        saltar();

    }

    public void moving()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
            runspeed++;

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runspeed, rb2D.velocity.y);
            runspeed++;

        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            runspeed = 10;
            Debug.Log("el pepe");
        }


    }
    public void saltar()
    {
        if (Input.GetKey("space") && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
        }
    }

 

}
