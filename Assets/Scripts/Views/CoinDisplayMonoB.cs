using UnityEngine;
using UnityEngine.UI;

public class CoinDisplayMonoB : MonoBehaviour
{
    Text coinDisplayText;
    public static int coinCounter;
    void Start()
    {
        coinDisplayText = GetComponent<Text>();
    }

    void Update()
    {
        coinDisplayText.text = "Coins: " + coinCounter.ToString();
    }
}
