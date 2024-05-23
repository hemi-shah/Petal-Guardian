using UnityEngine;
using UnityEngine.Serialization;

public class Pumpkin : Plant
{
    [FormerlySerializedAs("pumpkinHealth")] [SerializeField] private float PumpkinHealth = 40f;
    private new void Awake()
    { 
        IsProjectileFiringPlant = false;
        MaxHealth = PumpkinHealth;
        base.Awake();
    }
    
}