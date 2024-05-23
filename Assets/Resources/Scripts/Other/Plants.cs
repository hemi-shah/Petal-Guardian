using UnityEngine;

public class Plants : MonoBehaviour
{
    public double ProjectileFireRate { get; private set; } = 1;
    public float DamageCoefficient { get; private set; } = 1.0f;

    public bool PrintInfo = false;

    public void ApplyFireRateBuff(float amount)
    {
        ProjectileFireRate += amount;
        if(PrintInfo) print("Fire rate changed: " + ProjectileFireRate);
    }

    public void ApplyFireRateNerf(float amount)
    {
        ProjectileFireRate -= amount;
        if(PrintInfo) print("Fire rate changed: " + ProjectileFireRate);
    }

    public void ApplyDamageBuff(float amount)
    {
        DamageCoefficient += amount;
        if(PrintInfo) print("New damage coefficient: " + DamageCoefficient);
    }
    
    public void ApplyDamageNerf(float amount)
    {
        DamageCoefficient -= amount;
        if(PrintInfo) print("New damage coefficient: " + DamageCoefficient);
    }
}