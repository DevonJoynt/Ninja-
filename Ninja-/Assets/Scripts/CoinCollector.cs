using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    // Unity Event for this specific coin
    [Header("Events")]
    public UnityEvent onCollected = new UnityEvent();

    [SerializeField] private float rotateSpeed = 50f;

    private bool isCollected = false;

    private void Start()
    {
        CoinManage coinManager = FindObjectOfType<CoinManage>();
        onCollected.AddListener(coinManager.AddCoin);
    }
    void Update()
    {
        // Optional: rotate the coin
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;

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
            GetComponent<Collider2D>().enabled = false;

            // Destroy the coin
            Destroy(gameObject, 0.1f);
        }
    }
}