﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]

public class CoxBoyController : MonoBehaviour
{
    private float width;
    private float height;
    private float rayCastLengthCheck = 0.005f;

    public float speed = 14f;
    public float accel = 6f;

    private Vector2 input;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    public bool isJumping;
    public float jumpSpeed = 8f;
    public float jumpDurationThreshold = 0.25f;
    private float jumpDuration;
    public float airAccel = 3f;
    public float jump = 14f;


    void Awake()
    {

        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    public bool PlayerIsOnGround()
    {
        bool groundCheck1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), Vector2.down, rayCastLengthCheck);

        bool groundCheck2 = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height), Vector2.down, rayCastLengthCheck);

        bool groundCheck3 = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height), Vector2.down, rayCastLengthCheck);

        if (groundCheck1 || groundCheck2 || groundCheck3)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            return true;
        }

        return false;
    }

    public bool IsWallToLeftOrRight()
    {
        bool wallOnleft = Physics2D.Raycast(new Vector2(transform.position.x - width, transform.position.y), Vector2.left, rayCastLengthCheck);
        bool wallOnRight = Physics2D.Raycast(new Vector2(transform.position.x + width, transform.position.y), Vector2.right, rayCastLengthCheck);

        if (wallOnleft || wallOnRight)
        {
            return true;
        }
        return false;
    }

    public bool PlayerIsTouchingGroundOrWall()
    {
        if (PlayerIsOnGround() || IsWallToLeftOrRight())
        {

            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //obtener los valores X e Y de los controles de Unity ( Horizontal y Jump)
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Jump");

        animator.SetFloat("Speed", Mathf.Abs(input.x));

        // Si input.x es mayor que 0, entonces el jugador está mirando hacia la derecha, por lo que el sprite se voltea en el axis X
        if (input.x > 0f)
        {
            sr.flipX = false;
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
        }

        if (input.y >= 1f)
        {
            jumpDuration += Time.deltaTime;
            //todo animator isJumping true
            animator.SetBool("IsJumping", true);
        }
        else
        {
            isJumping = false;
            //todo animator isJumping false
            animator.SetBool("IsJumping", false);
            jumpDuration = 0f;

        }

        if (PlayerIsOnGround() && !isJumping)
        {
            if (input.y > 0f)
            {
                isJumping = true;
            }
            //todo animation isOnWall false
            animator.SetBool("IsOnWall", false);
            animator.SetBool("IsJumping", false);
        }

        if (jumpDuration > jumpDurationThreshold) input.y = 0f;
    }

    void FixedUpdate()
    {
        
        var acceleration = 0f;

        if (PlayerIsOnGround())
        {
            acceleration = accel;
        }
        else
        {
            acceleration = airAccel;
        }
        var xVelocity = 0f;

        // Si los controles del axis horizontal son neutrales, entonces xVelocity se establece en 0; 
        //sino, xVelocity se establece en la velocidad 'x' actual del componente Rigidbody2D(declarado como rb).
        if (PlayerIsOnGround() && input.x == 0)
        {
            xVelocity = 0f;
        }
        else
        {
            xVelocity = rb.velocity.x;
        }

        var yVelocity = 0f;
        if (PlayerIsTouchingGroundOrWall() && input.y == 1)
        {
            yVelocity = jump;
        }
        else
        {
            yVelocity = rb.velocity.y;
        }

        // La fuerza se agrega a rb calculando el valor actual de los controles del axis horizontal 
        //multiplicado por la velocidad, que a su vez se multiplica por la aceleración xDD

        var xForce = (input.x * speed - rb.velocity.x) * acceleration;
        rb.AddForce(new Vector2(xForce, 0));
        rb.velocity = new Vector2(xVelocity, yVelocity);

        if (IsWallToLeftOrRight() && !PlayerIsOnGround() && input.y == 1)
        {
            rb.velocity = new Vector2(-GetWallDirection() * speed * 0.75f, rb.velocity.y);
            //todo animator 1
            animator.SetBool("IsOnWall", false);
            animator.SetBool("IsJumping", true);


        }
        else if (!IsWallToLeftOrRight())
        {
            animator.SetBool("IsOnWall", false);
            animator.SetBool("IsJumping", true);
        }

        if (IsWallToLeftOrRight() && !PlayerIsOnGround())
        {
            animator.SetBool("IsOnWall", true);
        }

        //todo animator 2

        if (isJumping && jumpDuration < jumpDurationThreshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }




    //devuelve un número entero en función de si el muro es izquierdo (-1), derecho (1) o ninguno (0)
    public int GetWallDirection()
    {
        bool isWallLeft = Physics2D.Raycast(new Vector2(transform.position.x - width, transform.position.y), -Vector2.right, rayCastLengthCheck);
        bool isWallRight = Physics2D.Raycast(new Vector2(transform.position.x + width, transform.position.y), Vector2.right, rayCastLengthCheck);

        if (isWallLeft)
        {
            return -1;
        }
        else if (isWallRight)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }



}