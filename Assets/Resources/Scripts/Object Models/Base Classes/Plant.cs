using System.Collections;
using UnityEngine;

public class Plant : HealthObject
{
    protected float BaseFireRate = 1f;
    protected GameObject Projectile;
    protected bool IsProjectileFiringPlant = false;
    private float currentFireRate;
    protected float ProjectileDamage = 1f;
    protected float ProjectileSpeed = 1f;
    private Plants Plants;
    private new Camera camera;

    protected new void Awake()
    {
        camera = Camera.main;
        ObjectType = ObjectType.Plant;
        base.Awake();
        HealToMax();
        Plants = GameObject.FindGameObjectWithTag("PlantManager").GetComponent<Plants>();
        BaseFireRate = 1 / BaseFireRate;
        DeathParticleSystem = Resources.Load<GameObject>("Prefabs/Particles/Death/Death_Part_Plants");
    }

    protected new void Start()
    {
        base.Start();
        if (IsProjectileFiringPlant) StartCoroutine(WaitForGameStart());
        else if(ShouldPrint) print("Plant should not fire projectiles: " + ObjectName);
    }

    private IEnumerator WaitForGameStart()
    {
        yield return new WaitUntil(GameHasStarted);
        StartCoroutine(ProjectileLoop());
    }

    private bool GameHasStarted()
    {
        return Game.GameStarted;
    }

    private IEnumerator ProjectileLoop()
    {
        currentFireRate = BaseFireRate / (float)Plants.ProjectileFireRate;
        if (ShouldFireProjectile())
        {
            FireProjectile();
            yield return new WaitForSeconds(currentFireRate);
            StartCoroutine(ProjectileLoop());
        }
        else
        {
            yield return new WaitUntil(ShouldFireProjectile);
            StartCoroutine(ProjectileLoop());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void FireProjectile()
    {
        var firedProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        firedProjectile.GetComponent<Projectile>().Setup(ProjectileDamage*Plants.DamageCoefficient, ProjectileSpeed);
    }

    private bool ShouldFireProjectile()
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        var hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, mask);
        if (!hit.collider) return false;
        var screenPoint = camera.WorldToViewportPoint(hit.point);
        var isOnScreen = screenPoint.x is >= 0 and <= 1 && screenPoint.y is >= 0 and <= 1;
        return isOnScreen;
    }
    
}
