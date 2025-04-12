using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class CoinEvent : UnityEvent<int> { }

public class CoinManage : MonoBehaviour
{
    public int coinCount;  //tracks total coins collected
    public Text coinText;   //text that displays coin count

    // Add Unity Event
    [Header("Events")]
    public CoinEvent onCoinCollected = new CoinEvent(); //event fires when coin is collected passing updated count to listener

    void Start()
    {
        // Initialize UI - shows 0 coins at start
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();   //update with current coin count
    }

    public void AddCoin()
    {
        coinCount++;   //increase total coin count
       
        onCoinCollected.Invoke(coinCount);    // Fire the event with updated count

        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount.ToString();
        }
    }
}