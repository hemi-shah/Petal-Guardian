using System.Collections;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    protected float MaxHealth;
    protected string ObjectName;
    private float currentHealth;
    protected int PointsToGain = 0;
    private SpriteRenderer objectRenderer;
    protected ObjectType ObjectType = ObjectType.Unknown;
    protected Game Game;
    protected readonly bool ShouldPrint = false;
    protected GameObject DeathParticleSystem = null;
    private Coroutine fadeCoroutine;
    public Sounds Sounds;
    protected void Awake()
    {
        Sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
        objectRenderer = gameObject.GetComponent<SpriteRenderer>();
        ObjectName = gameObject.name;
        Game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }

    private void SendType()
    {
        switch (ObjectType)
        {
            case ObjectType.Plant or ObjectType.Flower:
                Game.IncreasePlantFlowerCount();
                break;
            case ObjectType.Enemy:
                Game.Waves.IncreaseEnemyCount();
                break;
        }
    }

    protected virtual void Update()
    {
        if (Game.GameOver) Die();
    }

    protected void Start()
    {
        HealToMax();
        SendType();
    }

    public void TakeDamage(float damageTaken)
    {
        if (WillDie(damageTaken)) Die();
        else currentHealth -= damageTaken;
        TriggerDamageEffect();
    }

    private void TriggerDamageEffect()
    {
        StopFadeIfRunning();
        fadeCoroutine = StartCoroutine(FadeOpacity());
    }

    private IEnumerator FadeOpacity()
    {
        var color = objectRenderer.color;
        var startOpacity = color.a; 
        var targetOpacity = (currentHealth / MaxHealth);
        const float fadeDuration = 0.3f;
        var timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            var newOpacity = Mathf.Lerp(startOpacity, targetOpacity, timeElapsed / fadeDuration);
            var newColor = objectRenderer.color;
            newColor.a = newOpacity;
            objectRenderer.color = newColor;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        var finalColor = objectRenderer.color;
        finalColor.a = targetOpacity;
        objectRenderer.color = finalColor;
    }

    private void TriggerDeathEffect()
    {
        if (DeathParticleSystem)
        {
            Instantiate(DeathParticleSystem, transform.position, Quaternion.identity);
        }

        if (!Sounds) return;
        switch (ObjectType)
        {
            case ObjectType.Plant:
                Sounds.PlayLosingPlantSound();
                break;
            case ObjectType.Enemy:
                // Sounds.Play
                break;
            case ObjectType.Flower:
                Sounds.PlayLosingFlowerSound();
                break;
        }
    }

    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > MaxHealth) {
            currentHealth = MaxHealth;
        }
    }
    
    public void HealToMax()
    {
        currentHealth = MaxHealth;
        StopFadeIfRunning();
        fadeCoroutine = StartCoroutine(FadeOpacity());
    }

    private void StopFadeIfRunning()
    {
        if (fadeCoroutine == null) return;
        StopCoroutine(fadeCoroutine);
        var color = objectRenderer.color;
        color.a = (currentHealth / MaxHealth);
    }

    public void PrintHealth()
    {
        Debug.Log(ObjectName + "'s current health: " + currentHealth);
    }

    private bool WillDie(float damageTaken)
    {
        return (currentHealth - damageTaken <= (0.05f*MaxHealth));
    }

    private void Die()
    {
        switch (ObjectType)
        {
            case ObjectType.Plant or ObjectType.Flower:
                Game.DecreasePlantFlowerCount();
                break;
            case ObjectType.Enemy:
                Game.Waves.DecreaseEnemyCount();
                break;
        }
        if(ShouldPrint) print(ObjectName + " Died");
        Score.AddScore(PointsToGain);
        TriggerDeathEffect();
        Destroy(gameObject);
    }
}
