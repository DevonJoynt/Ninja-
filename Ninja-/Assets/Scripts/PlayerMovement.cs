using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    [SerializeField] private float speed; // player movement speed

    private Rigidbody2D body;

    private Animator anim;   //reference to animator component

    private bool grounded;   //tracks if player is touching ground

    private bool m_FacingRight;   //tracks which direction player is facing

    public CoinManage cm;   //reference to coin manager

    private void Awake()

    {

        //Grab references for rigidbody and animator from object 

        body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame 

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");  //gets horizonal input axis

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);



        //Flip player when moving Left to Right 

        if (horizontalInput > 0.01f)

            transform.localScale = Vector3.one;   //moving right

        else if (horizontalInput < -0.01f)

            transform.localScale = new Vector3(-1, 1, 1);   //moving left



        if (Input.GetKey(KeyCode.Space) && grounded) // button on keyboard used for jumping

            Jump();

      



        //set animator parameters 

        anim.SetBool("run", horizontalInput != 0);

        anim.SetBool("grounded", grounded);  //grounded animation parameter

    }

    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, speed);

        anim.SetTrigger("jump");   // Trigger jump animation

        grounded = false;   // Set grounded to false as player is now in the air

    }
    

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.tag == "Ground")   // enable jumping if player collides with object tagged as "Ground"

            grounded = true;

    }
    private void Flip()  //flips player left to right and right to left.
    {
        m_FacingRight = !m_FacingRight;  

        transform.Rotate(0f, 180f, 0f);  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))  //checks if player enters coin trigger
        {
            Destroy(other.gameObject); // coin destroyed after player collects.
            cm.coinCount++;
        }
    }

}