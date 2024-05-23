using UnityEngine;
using UnityEngine.Serialization;

public class Corn : Plant
{
    [FormerlySerializedAs("cornHealth")] [SerializeField] private float CornHealth = 10f;
    [FormerlySerializedAs("cornDamage")] [SerializeField] private float CornDamage = 1f;
    [FormerlySerializedAs("cornProjectileSpeed")] [SerializeField] private float CornProjectileSpeed = 1f;
    [FormerlySerializedAs("cornFireRate")] [SerializeField] private float CornFireRate = 1f;
    private new void Awake()
    { 
        IsProjectileFiringPlant = true;
        Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
        BaseFireRate = CornFireRate * Mathf.Clamp(CornProjectileSpeed*0.6f, 1, 1.5f);
        ProjectileDamage = CornDamage;
        ProjectileSpeed = CornProjectileSpeed;
        MaxHealth = CornHealth;
        base.Awake();
    }
    
}