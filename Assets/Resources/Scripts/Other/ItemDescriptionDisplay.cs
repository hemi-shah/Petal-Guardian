using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemDescriptionDisplay : MonoBehaviour
{
    private Text descriptionText;
    private Image itemImage;
    private Image backgroundPanel;  // This will still use the green/red box sprites
    [FormerlySerializedAs("greenBoxSprite")] public Sprite GreenBoxSprite;  // Assign in the Inspector
    [FormerlySerializedAs("redBoxSprite")] public Sprite RedBoxSprite;    // Assign in the Inspector
    [FormerlySerializedAs("wallet")] public Wallet Wallet;


    private void Awake()
    {
        itemImage = GameObject.FindGameObjectWithTag("ItemDisplayImage").GetComponent<Image>();
        backgroundPanel = GameObject.FindGameObjectWithTag("ItemDisplayBackgroundPanel").GetComponent<Image>();
        descriptionText = GameObject.FindGameObjectWithTag("ItemDisplayText").GetComponent<Text>();
        Wallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
        Clear();
    }


    public void UpdateDescription(string description, Sprite icon, float itemPrice)
    {
        descriptionText.text = description;   
        itemImage.sprite = icon;
      //  wallet.wallet = itemPrice;         //Cant figure this one out!!
     
       backgroundPanel.sprite = Wallet.HasEnoughToBuyItem(itemPrice) ? GreenBoxSprite : RedBoxSprite;
       //backgroundPanel.sprite = greenBoxSprite;
       var color = itemImage.color;
       color.a = 1;
       itemImage.color = color;
    }

    private void Clear()
    {
        descriptionText.text = "";
        var color = itemImage.color;
        color.a = 0;
        itemImage.color = color;
    }
}



