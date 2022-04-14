using UnityEngine;
using UnityEngine.UI;

public class CoinCounterMonoB : MonoBehaviour
{
    private string coinTag = "Coin";
    public Text coinDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            CoinDisplayMonoB.coinCounter += 1;
            other.gameObject.SetActive(false);
        }
    }
}
