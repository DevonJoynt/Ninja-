using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RobotBoss : MonoBehaviour
{
    public int LifeTotal;  //just added
    public float speed;
    public float chaseDistance;
    public float stopDistance;
    public GameObject target;

    public Rigidbody2D rb; //Just added

    private float targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   //just added
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;

        targetDistance = Vector2.Distance(transform.position, target.transform.position);
        if (targetDistance < chaseDistance && targetDistance > stopDistance)
            ChasePlayer();
        else
            StopChasePlayer();
    }
    private void StopChasePlayer()
    {
        //do nothing
    }
    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
            GetComponent<SpriteRenderer>().flipX = false;
        else
            GetComponent<SpriteRenderer>().flipX = true;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
