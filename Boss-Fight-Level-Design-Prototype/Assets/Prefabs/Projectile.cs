using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D ThingIHit)
    {
        if (ThingIHit.tag == "Enemy")
        {
            ThingIHit.GetComponent<EnemyBehaviour>().LifeTotal--;

            if (ThingIHit.GetComponent<EnemyBehaviour>().LifeTotal == 0)
            {
                Destroy(ThingIHit.gameObject);
            }

        }
        Destroy(gameObject);
    }
}
