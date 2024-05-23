using UnityEngine;

public class Rose : Flower
{
    private Plants plants;
    private readonly float damageBuffAmount = 0.15f;
    
    private new void Awake()
    {
        base.Awake();
        plants = GameObject.FindGameObjectWithTag("PlantManager").GetComponent<Plants>();
        plants.ApplyDamageBuff(damageBuffAmount);
        DeathParticleSystem = Resources.Load<GameObject>("Prefabs/Particles/Death/Death_Part_Rose");
    }
    private new void Update()
    {
        base.Update();
    }

    private void OnDestroy()
    {
        plants.ApplyDamageNerf(damageBuffAmount);
    }
}