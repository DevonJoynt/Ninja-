using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * transform.localScale.x, 0f);
    }
}
