using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class CoinEvent : UnityEvent<int> { }

public class CoinManage : MonoBehaviour
{
    public int coinCount;
    public Text coinText;

    // Add Unity Event
    [Header("Events")]
    public CoinEvent onCoinCollected = new CoinEvent();

    void Start()
    {
        // Initialize UI
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++;
        // Fire the event
        onCoinCollected.Invoke(coinCount);
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