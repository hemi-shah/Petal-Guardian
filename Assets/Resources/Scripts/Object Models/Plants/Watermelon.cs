using UnityEngine;
using UnityEngine.Serialization;

public class Watermelon : Plant
{
    [FormerlySerializedAs("melonHealth")] [SerializeField] private float MelonHealth = 15f;
    [FormerlySerializedAs("melonDamage")] [SerializeField] private float MelonDamage = 7f;
    [FormerlySerializedAs("melonProjectileSpeed")] [SerializeField] private float MelonProjectileSpeed = 0.5f;
    [FormerlySerializedAs("melonFireRate")] [SerializeField] private float MelonFireRate = 0.5f;
    private new void Awake()
    { 
        IsProjectileFiringPlant = true;
        Projectile = Resources.Load<GameObject>("Prefabs/WatermelonProjectile");
        BaseFireRate = MelonFireRate * Mathf.Clamp(MelonProjectileSpeed*0.6f, 0.03f, 0.8f);
        ProjectileDamage = MelonDamage;
        ProjectileSpeed = MelonProjectileSpeed;
        MaxHealth = MelonHealth;
        base.Awake();
    }
}
