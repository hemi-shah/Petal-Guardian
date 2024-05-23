using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [FormerlySerializedAs("playerWallet")] public Wallet PlayerWallet;
 

    private void Awake()
    {
        PlayerWallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
    }

    private Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        {"Watermelon", 7}, {"Corn", 7}, {"Mushroom", 10}, {"Pumpkin", 12},
        {"Daisy", 5},{"Rose", 10}, {"MoneyFlower", 18},
        {"Fertilizer", 40}
    };

    public void BuyItem(string itemName)
    {
        if (!itemPrices.ContainsKey(itemName)) return;
        var itemPrice = itemPrices[itemName];
        if (PlayerWallet.HasEnoughToBuyItem(itemPrice))
        {
            PlayerWallet.RemoveMoney(itemPrice);
            Debug.Log("Purchased " + itemName);
        }
        else
        {
            Debug.Log("Not enough money to buy " + itemName);
        }

    }
    
}


