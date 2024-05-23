using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileDamage { get; private set; }
    private bool shouldTriggerDeathEffect = true;
    private float projectileSpeed;
    private new Camera camera;
    private Waves waves;

    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
        waves = GameObject.FindGameObjectWithTag("Game").GetComponent<Waves>();
    }

    public void Setup(float damage, float speed)
    {
        ProjectileDamage = damage;
        projectileSpeed = speed;
    }

    private void Update()
    {
        transform.Translate(projectileSpeed*Time.deltaTime, 0f, 0f);
        CheckIfOffScreen();
        CheckIfWaveHasEnded();
    }

    private void CheckIfOffScreen()
    {
        var worldPos = camera.WorldToScreenPoint(transform.position);
        if (!(worldPos.x > Screen.width)) return;
        shouldTriggerDeathEffect = false;
        Destroy(gameObject);
    }

    private void CheckIfWaveHasEnded()
    {
        if (waves.CurrentMode != Waves.Mode.Prep) return;
        shouldTriggerDeathEffect = false;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (shouldTriggerDeathEffect)
        {
            
        }
    }
}
