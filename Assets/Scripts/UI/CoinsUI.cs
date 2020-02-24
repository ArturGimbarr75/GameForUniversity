using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{

    /// <summary>
    /// Contains max 9 digits number
    /// </summary>
    private Text CoinsText;

    private const string CoinsStr = " Coins: "; 

    void Start()
    {
        CoinsText = this.GetComponent<Text>();
        CoinsText.text = CoinsStr + Coin.GetCoinsCount().ToString();
    }

    void Update()
    {
        CoinsText.text = CoinsStr + Coin.GetCoinsCount().ToString();
    }
}
