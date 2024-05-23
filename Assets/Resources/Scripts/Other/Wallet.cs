using System.Collections;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float money = 100f; 
    private float moneyCycleAmount;
    private float moneyCycleSeconds = 4f;
    public bool PrintInfo = false;
    public UpdateWalletDisplay WalletDisplayUpdater;

    private void Awake()
    {
    }

    public void StartGeneratingMoney()
    {
        StartCoroutine(AddMoneyFromCycle());
    }

    public float GetMoney()
    {
        return money;
    }

    public void AddMoney(float moneyToAdd)
    {
        money += moneyToAdd;
        WalletDisplayUpdater.UpdateDisplay(this.money);
    }

    public bool HasEnoughToBuyItem(float itemCost)
    {
        return money >= itemCost;
    }

    public void RemoveMoney(float money)
    {
        this.money -= money;
        WalletDisplayUpdater.UpdateDisplay(this.money);
    }

    private IEnumerator AddMoneyFromCycle()
    {
        AddMoney(moneyCycleAmount);
        yield return new WaitForSeconds(moneyCycleSeconds);
        if(PrintInfo) print("Money cycle complete. Current amount of money: " + money + " (Cycle amount: " + moneyCycleAmount + ")");
        StartCoroutine(AddMoneyFromCycle());
    }

    public void AdjustMoneyCycleAmount(float change)
    {
        moneyCycleAmount += change;
        if(PrintInfo) print("Money cycle amount changed by " + change + " to " + moneyCycleAmount);
    }
}
