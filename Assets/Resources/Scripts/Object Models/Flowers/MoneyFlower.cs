using UnityEngine;

public class MoneyFlower : Flower
{
    private Wallet wallet;
    private readonly float moneyBuffAmount = 2f;
    
    private new void Awake()
    {
        base.Awake();
        wallet = GameObject.FindGameObjectWithTag("Wallet").GetComponent<Wallet>();
        wallet.AdjustMoneyCycleAmount(moneyBuffAmount);
        DeathParticleSystem = Resources.Load<GameObject>("Prefabs/Particles/Death/Death_Part_MoneyFlower");
    }
    private new void Update()
    {
        base.Update();
    }

    private void OnDestroy()
    {
        wallet.AdjustMoneyCycleAmount(-moneyBuffAmount);
    }
}
