using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Basic : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sRenderer;
    public float speed = 1f;
    private float waittime;

    public Transform[] moveSpots;

    public float startWaittime = 2;
    private int i = 0;

    

    private Vector2 actualPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        waittime = startWaittime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckEnemyMoving());


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.2f)
        {
            if (waittime <= 0)
            {
                if (moveSpots[i]!=moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waittime = startWaittime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
    }


    IEnumerator CheckEnemyMoving()
    {
        actualPosition = transform.position;

        yield return new WaitForSeconds(1f);

        if (transform.position.x > actualPosition.x)
        {
            sRenderer.flipX = true;
        }
        else if (transform.position.x < actualPosition.x)
        {
            sRenderer.flipX = false;
        }        
    }
}
