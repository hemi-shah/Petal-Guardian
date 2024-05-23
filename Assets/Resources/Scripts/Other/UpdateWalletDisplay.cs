using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpdateWalletDisplay : MonoBehaviour
{
    [FormerlySerializedAs("wallet")] public Wallet Wallet;  // Reference to Wallet script
    [FormerlySerializedAs("moneyText")] public Text MoneyText; // Reference to Text component where money will be displayed

    private void Start()
    {
        if (Wallet == null)
            Wallet = FindObjectOfType<Wallet>(); // Find the Wallet component in the scene
        
        if (MoneyText == null)
            MoneyText = GetComponent<Text>(); // Get the Text component on this GameObject

        
        UpdateDisplay(Wallet.GetMoney()); // Initial update
    }

    private void OnDestroy()
    {
        
    }

    // Modified to accept a float parameter
    public void UpdateDisplay(float money)
    {
        if (MoneyText)
            MoneyText.text = "$" + money.ToString("F2"); // Format to 2 decimal places
    }
}

