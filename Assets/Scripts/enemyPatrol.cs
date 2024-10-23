using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyPatrol : MonoBehaviour
{
    //going form point a to point b in game
    public GameObject pointA;
    public GameObject pointB;
    //getting rigidbody and animation
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        //starting off the animation with runnig
        anim.SetBool("isRunning", true);

    }

    // Update is called once per frame
    void Update()
    {
        //giving the direction to current point, which is b
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        //if current point is not point b (aka point a), changes direction
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
