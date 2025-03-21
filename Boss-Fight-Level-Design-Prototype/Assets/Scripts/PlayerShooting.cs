using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Projectile;
    public Transform FirePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject bulletClone = (GameObject)Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
            bulletClone.transform.localScale = transform.localScale;
        }
    }
}
