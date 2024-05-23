public class FertilizerButton : ShopButton
{
    private protected override void OnButtonClick()
    {
        var powerups = FindObjectOfType<Powerups>();

        // Attempt to purchase the item + play correlated sound
        if (Wallet.HasEnoughToBuyItem(Price))
        {
            Shop.BuyItem(ItemName); //purchase
            powerups.ApplyFertilizer();
            Sounds.PlaySelectingSound(); // Play sound selection/purchase   
        }
        else
        {
            Sounds.PlayCantAffordSound(); // Play sound  can't afford
        }
    }
}
