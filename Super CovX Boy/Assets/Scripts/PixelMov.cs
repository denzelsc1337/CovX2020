using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer render;
    public float walkspeed;
    public float jumpspeed;
    private float mvInput;
    public bool isGrounded;
    private bool isTouchingizquierda;
    private bool isTouchingDerecha;
    private bool saltoMuro;
    private Animator m_animacion;

    private float tocandoIzqODrch;

    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponent<SpriteRenderer>();
        m_animacion = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        mvInput = Input.GetAxis("Horizontal");

        if ((!isTouchingizquierda && !isTouchingDerecha) || isGrounded)
        {
            rb.velocity = new Vector2(mvInput * walkspeed, rb.velocity.y);
        }


        if (mvInput > 0f)
        {
            render.flipX = false;
        }
        else if (mvInput < 0f)
        {
            render.flipX = true;
        }

        if (mvInput != 0)
        {
            m_animacion.SetBool("walking", true);
        }
        else
        {
            m_animacion.SetBool("walking", false);
        }


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            Debug.Log("Salto constante? Vizcarra tu tienes la culpa xD");
        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.9f, 0.2f), 0f, groundMask);

        isTouchingizquierda = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y),
            new Vector2(0.2f, 0.9f), 0f, groundMask);

        isTouchingDerecha = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y),
            new Vector2(0.2f, 0.9f), 0f, groundMask);

        if (isTouchingizquierda)
        {
            tocandoIzqODrch = 1;
        }
        else if (isTouchingDerecha)
        {
            tocandoIzqODrch = -1;
        }

        if (Input.GetKeyDown("space") && (isTouchingDerecha || isTouchingizquierda) & !isGrounded)
        {
            saltoMuro = true;
            Debug.Log("En la pared no se podra saltar varias veces xD");
            Invoke("SetJumpingToFalse", 0.08f);
        }

        if (saltoMuro)
        {
            rb.velocity = new Vector2(walkspeed * tocandoIzqODrch, jumpspeed);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.87f), new Vector2(0.9f, 0.2f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));
    }

    void SetJumpingToFalse()
    {
        saltoMuro = false;
    }
}
