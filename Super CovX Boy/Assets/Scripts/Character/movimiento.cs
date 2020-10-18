using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movimiento : MonoBehaviour
{
    public float runspeed;
    public float jumpspeed;
    private Rigidbody2D rb2D;
    public static float conteo = 0.0f;
    public static float total = 0;
    private Button Izquierdass, Derechass;
    private Animator m_animacion;
    public static float jumps;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        m_animacion = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void FixedUpdate()
    {
        moving();
        saltar();

    }

    public void moving()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
            rb2D.AddForce(new Vector2(runspeed, rb2D.velocity.y));
            //rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
            //runspeed++;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.AddForce(new Vector2(-runspeed, rb2D.velocity.y));
            //rb2D.velocity = new Vector2(-runspeed, rb2D.velocity.y);
            //runspeed++;

        }
        else
        {
            //rb2D.AddForce(new Vector2(0, rb2D.velocity.y));
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        //if (Input.GetKeyUp("d") || runspeed > 200)
        //{
        //    runspeed = 10;
        //    Debug.Log("el pepe");

        //}else if (Input.GetKeyUp("a"))
        //{
        //    runspeed = 10;
        //    Debug.Log("ete sech");
        //}

    }
    public void saltar()
    {
        if (Input.GetKey("space") && checkGround.isGrounded)
        {
            //rb2D.AddForce(new Vector2(rb2D.velocity.x, jumpspeed));
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
            conteo++;
            total = jumpsCounter.jumpValue = conteo;
        }
    }

 

}
