using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour

{

    public float health;  //players current health

    public float maxHealth;  //maximum possible health

    public Image healthBar;   //displays UI image of health



    private bool isDead;   //tracks if player has died



    public GameManagerScript gameManager;

    // Start is called before the first frame update 

    void Start()

    {

        maxHealth = health;   //sets manimum health equal to starting health

    }



    // Update is called once per frame 

    void Update()

    {

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);



        if (health <= 0 && !isDead)  //check for death condition

        {

            isDead = true;

            gameObject.SetActive(false);   //disable player object

            gameManager.gameOver();   //triggers game over screen

            Debug.Log("Dead");

        }

    }

    internal void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}