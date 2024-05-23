using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour

{
    [FormerlySerializedAs("itemName")] public string ItemName;
    [FormerlySerializedAs("description")] public string Description;
    [FormerlySerializedAs("price")] public float Price;
    [FormerlySerializedAs("icon")] public Sprite Icon;
    [FormerlySerializedAs("prefab")] public GameObject Prefab;
    
    protected Wallet Wallet;
    protected Sounds Sounds;
    protected Shop Shop;
    private ItemDescriptionDisplay DescriptionDisplay;

    private Button Button;

    private void Awake()
    {
        Wallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
        Sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
        Shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        DescriptionDisplay = FindObjectOfType<ItemDescriptionDisplay>();
    }

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OnButtonClick);
    }

    private protected virtual void OnButtonClick()
    {
        // Update item description display
        if (DescriptionDisplay)
        {
            DescriptionDisplay.UpdateDescription(Description, Icon, Price);
        }

        // Attempt to purchase the item + play correlated sound
        if (Wallet.HasEnoughToBuyItem(Price))
        {
            if (!ShopSelection.PrefabHasPlaced()) return;
            Shop.BuyItem(ItemName); //purchase
            ShopSelection.SetSelectedItem(Prefab);
            Sounds.PlaySelectingSound(); // Play sound selection/purchase   
        }
        else
        {
            Sounds.PlayCantAffordSound(); // Play sound  can't afford
        }
    }
}


