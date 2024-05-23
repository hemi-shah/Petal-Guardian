using UnityEngine;

public class Daisy : Flower
{
    private Plants plants;
    private readonly float fireRateBuffAmount = 0.25f;
    
    private new void Awake()
    {
        base.Awake();
        plants = GameObject.FindGameObjectWithTag("PlantManager").GetComponent<Plants>();
        plants.ApplyFireRateBuff(fireRateBuffAmount);
        DeathParticleSystem = Resources.Load<GameObject>("Prefabs/Particles/Death/Death_Part_Daisy");
    }
    private new void Update()
    {
        base.Update();
    }

    private void OnDestroy()
    {
        plants.ApplyFireRateNerf(fireRateBuffAmount);
    }
}
