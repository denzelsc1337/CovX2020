using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movimiento : MonoBehaviour
{
    public float runspeed;
    public float jumpspeed;
    private Rigidbody2D rb2D;

    public SpriteRenderer SpriteRenderer;


    public static float conteo = 0.0f;
    public static float total = 0;
    
    public Animator animator;
    public static float jumps;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
            //rb2D.AddForce(new Vector2(runspeed, rb2D.velocity.y));
            rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
            SpriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            //runspeed++;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //rb2D.AddForce(new Vector2(-runspeed, rb2D.velocity.y));
            rb2D.velocity = new Vector2(-runspeed, rb2D.velocity.y);
            SpriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            //runspeed++;

        }
        else
        {
            //rb2D.AddForce(new Vector2(0, rb2D.velocity.y));
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
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

        if (checkGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (checkGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

 

}
