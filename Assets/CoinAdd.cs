using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{

    public GameObject coin;
    private int coins = 0;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Finish"))
        {
            GameObject coinInst = Instantiate(coin, transform);
            Destroy(coinInst, 0.5f);
            coins++;
            coinText.text = coins.ToString();
        }
    }
}
