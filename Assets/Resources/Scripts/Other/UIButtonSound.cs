using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    // private Wallet playerWallet; // Reference ->  Wallet 
    // public float itemCost;      // Cost of the item (button)
    // private Sounds sounds;
    // private Button button;
    // private Shop shop;
    //this script is now irrelevant!
    //
    // void Awake()
    // {
    //     playerWallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
    //     sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
    //     shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
    // }
    // void Start()
    // {
    //     button = GetComponent<Button>();
    //     button.onClick.AddListener(PlayAppropriateSound);
    // }
    //
    // private void PlayAppropriateSound()
    // {
    //     if (playerWallet == null)
    //     {
    //         Debug.LogError("Wallet reference not set on " + gameObject.name);
    //         return;
    //     }
    //
    //     if (playerWallet.HasEnoughToBuyItem(itemCost))
    //     {
    //         sounds.PlaySelectingSound();
    //     }
    //     else
    //     {
    //         sounds.PlayCantAffordSound();
    //     }
    // }
}


