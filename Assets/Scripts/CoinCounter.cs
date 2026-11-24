using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int coins;
    private int coinsToWin;

    void OnEnable()  { Coin.Collected += AddCoin; }
    void OnDisable() { Coin.Collected -= AddCoin; }

    void Start()
    {
        coinsToWin = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        UpdateText();
    }

    private void AddCoin()
    {
        coins++;
        UpdateText();
        Debug.Log($"Coins: {coins} / {coinsToWin}");
        if (coins == coinsToWin)
        {
            Debug.Log("All coins collected!");
            if (scoreText != null) scoreText.text = "All coins collected!";
        }
    }

    private void UpdateText()
    {
        if (scoreText != null)
            scoreText.text = $"Coins: {coins} / {coinsToWin}";
    }
}