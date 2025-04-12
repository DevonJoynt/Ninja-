using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    // Unity Event for this specific coin
    [Header("Events")]
    public UnityEvent onCollected = new UnityEvent();   //fires when specific coin collected

    [SerializeField] private float rotateSpeed = 50f;    //controls speed of roataing coin

    private bool isCollected = false;  //prevents coin from being collected more than once

    private void Start()
    {
        CoinManage coinManager = FindObjectOfType<CoinManage>();   //find coin manager in scene
        //listen for collection events
        onCollected.AddListener(coinManager.AddCoin);   //when the coin is collected the counter gets updated
    }
    void Update()
    {
        // Optional: rotate the coin
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player")) //only collects coin if not collected
        {
            isCollected = true;   //marks coin as collected

            // Fire the local event
            onCollected.Invoke();

            //// Find and update the coin manager
            //CoinManage coinManager = FindObjectOfType<CoinManage>();
            //if (coinManager != null)
            //{
            //    coinManager.AddCoin();
            //}
            

            // Hide the coin
            GetComponent<SpriteRenderer>().enabled = false;

            //prevents more collection
            GetComponent<Collider2D>().enabled = false;

            // Destroy the coin
            Destroy(gameObject, 0.1f);
        }
    }
}