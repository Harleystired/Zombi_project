using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public static int coin = 0;
    
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin++;
            coinText.text = "Coin: " + coin;
            Debug.Log(coin);
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        coinText.text = "Coin: " + coin;
    }
}
