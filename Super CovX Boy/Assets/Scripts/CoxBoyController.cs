using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]

public class CoxBoyController : MonoBehaviour
{
    //public bool zoomActive;
    //public Camera cam;
    //public float speedCam;

    public static bool frozen;
    public GameObject particle;
    public string axisName = "Horizontal";
    public static CharacterController control;
    public ParticleSystem dust;
    public Transform player;
    public float posY;
    public float posX;

    public static int jumps;
    public static int deaths;

    [Header("Cantidad de mascarillas")]
    public int questMascarillas;
    public static int masks;
    public GameObject portalFinal;

    private float width;
    private float height;
    private float rayCastLengthCheck = 0.005f;

    public float speed = 14f;
    public float accel = 6f;

    public static Vector2 input;
    private Vector2 inputTouch;
    Vector2 startPos;
    public int mascarNum;

    private SpriteRenderer sr;
    private static Rigidbody2D rb;
    public static Animator animator;

    public bool isJumping;
    public float jumpSpeed = 8f;
    public float jumpDurationThreshold = 0.25f;
    private float jumpDuration;
    public float airAccel = 3f;
    public float jump = 14f;

    private float screenCenterX;
    public float screenWith;

    public Button botonRight;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Application.targetFrameRate = 300;
        screenCenterX = Screen.width * 0.5f;
        screenWith = Screen.width / 2;
        masks = PlayerPrefs.GetInt("mascarillas");

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 1f;
        control = GetComponent<CharacterController>();

        sr = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
        this.player = GameObject.FindWithTag("Player").transform;
        startPos = this.transform.position;


    }
    public bool PlayerIsOnGround()
    {
        bool groundCheck1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, rayCastLengthCheck);
        bool groundCheck2 = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLengthCheck);
        bool groundCheck3 = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLengthCheck);


        if (groundCheck1 || groundCheck2 || groundCheck3)
        {
            isJumping = false;
            //Debug.Log("tocando suelo");
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
        else
        {

        }

        return false;
    }

    // Start is called before the first frame update




    // Update is called once per frame
    void Update()
    {
        //obtener los valores X e Y de los controles de Unity ( Horizontal y Jump)
        input.x = SimpleInput.GetAxisRaw("Horizontal");
        input.y = SimpleInput.GetAxisRaw("Jump");
        animator.SetFloat("Speed", Mathf.Abs(input.x));



#if UNITY_ANDROID || UNITY_IOS
        input.y = SimpleInput.GetAxisRaw("Vertical");

#endif
        // Si input.x es mayor que 0, entonces el jugador está mirando hacia la derecha, por lo que el sprite se voltea en el axis X
        if (input.x > 0f)
        {
            sr.flipX = false;
            CreateDust();
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
            CreateDust();
        }
        if (input.y >= 1f)
        {
            jumpDuration += Time.deltaTime;
            //todo animator isJumping true
            animator.SetBool("IsJumping", true);
            CreateDust();
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

            CreateDust();
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



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            //player.gameObject.transform.position = new Vector2(posX, posY);
            //phrases();
            this.transform.position = startPos;
            Debug.Log("prueba");
            //collision.gameObject.transform.position = new Vector2(-7.173035f, -9.06f);
            deaths += 1;
        }
        if (collision.tag =="mask")
        {
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            ////particle.SetActive(true);
            //masks += 1;
            ////singleLevel.instance.startLevel(masks);
            //if (masks >= questMascarillas)
            //{
            //    portalFinal.gameObject.SetActive(true);
            //}
            //else
            //{
            //    portalFinal.gameObject.SetActive(false);
            //}
            //Destroy(collision.gameObject,0.2f);


            //Debug.Log("contando");
            //collision.gameObject.transform.position = new Vector2(-7.173035f, -9.06f);
            
            //PlayerPrefs.DeleteAll();
            //PlayerPrefs.SetInt("mascarillas", masks);
        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 100, 100), "Mascarillas: " + masckCollected.masks.ToString());
        //GUI.Label(new Rect(20, 20, 100, 100), "Muertes: " + deaths.ToString() + "\nSaltos: " + jumps.ToString() + "\nMascarillas: " + masckCollected.masks.ToString());
    }

    void CreateDust()
    {
        dust.Play();
    }

    public static void cancelControls()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
    public static void GiveBackControls()
    {
        frozen = true;
    }

    public static void phrases()
    {
        switch (deaths)
        {
            case 1: Debug.Log("Nice Work"); break;
            case 2: Debug.Log("1337"); break;
            case 3: Debug.Log("villa = design xD"); break;
            case 4: Debug.Log("145"); break;
            case 5: Debug.Log("worky worky"); break;
            case 6: Debug.Log("monday morning lunatic :D"); break;
            default:
                break;
        }
        if (deaths == 0)
        {
            Debug.Log("Acaso no lo viste venir? :D");
        }
    }






}




