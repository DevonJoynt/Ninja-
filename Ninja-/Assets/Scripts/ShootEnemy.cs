using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fireball;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject FireballClone = (GameObject)Instantiate(Fireball, FirePoint.transform.position, FirePoint.transform.rotation);
            FireballClone.transform.localScale = transform.localScale;
        }

    }
}
