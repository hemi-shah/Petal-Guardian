using UnityEngine;
using UnityEngine.Serialization;

public class Mushroom : Plant
{
    [FormerlySerializedAs("mushroomHealth")] [SerializeField] private float MushroomHealth = 10f;

    private new void Awake()
    {
        IsProjectileFiringPlant = false;
        MaxHealth = MushroomHealth;
        base.Awake();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bee")) return;
        var bee = other.GetComponent<Bee>();
        if(bee) {
            bee.ChangeDirection();
        }
    }
}