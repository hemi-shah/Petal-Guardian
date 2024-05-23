using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : HealthObject
{
    protected bool MoveRight;
    [FormerlySerializedAs("baseSpeed")] [SerializeField]
    protected float BaseSpeed = 0.25f;
    protected float Speed;
    private float prevSpeed;
    private new Camera camera;
    protected float DamageToDeal = 5f;
    protected GameObject Target;
    private SpriteRenderer spriteRenderer;

    protected new void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera = FindObjectOfType<Camera>();
        ObjectType = ObjectType.Enemy;
        base.Awake();
        Speed = BaseSpeed;
        MaxHealth = 5f;
        HealToMax();
        DeathParticleSystem = Resources.Load<GameObject>("Prefabs/Particles/Death/Death_Part_Enemy");
    }

    protected new void Start()
    {
        ObjectType = ObjectType.Enemy;
        base.Start();
    }

    protected override void Update()
    {
        if (Speed > 0f) Move();
        base.Update();
        var worldPos = camera.WorldToScreenPoint(transform.position);
        if (worldPos.x < Game.LeftEdgeOfScreenXPos) Game.Lose();
    }

    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime*Speed);   
    }

    private void StopMoving()
    {
        prevSpeed = Speed;
        Speed = 0f;
    }

    private void StartMovingAgain()
    {
        if (prevSpeed > 0f) Speed = prevSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Flower":
                StopMoving();
                Attack(other.gameObject);
                break;
            case "Plant":
                StopMoving();
                Attack(other.gameObject);
                break;
            case "Mushroom":
                other.gameObject.GetComponent<Plant>().TakeDamage(DamageToDeal*0.5f);
                break;
            case "Projectile":
                TakeDamage(other.gameObject.GetComponent<Projectile>().ProjectileDamage);
                Destroy(other.gameObject);
                break;
            default:
                StartMovingAgain();
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Plant":
                Attack(other.gameObject);
                break;
            case "Flower":
                Attack(other.gameObject);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Plant":
                StartMovingAgain();
                break;
            case "Flower":
                StartMovingAgain();
                break;
        }
    }
    

    private void Attack(GameObject target)
    {
        switch (target.tag)
        {
            case "Plant":
                target.GetComponent<Plant>().TakeDamage(DamageToDeal * Time.deltaTime);
                break;
            case "Flower":
                target.GetComponent<Flower>().TakeDamage(DamageToDeal * Time.deltaTime);
                break;
            default:
                print("Error: nothing could be attacked (Enemy.cs)");
                break;
        }
    }

    private IEnumerator WaitToChangeDirectionBack()
    {
        yield return new WaitForSeconds(1.2f);
        MoveRight = false;
        spriteRenderer.flipX = false;
    }

    public void ChangeDirection()
    {
        MoveRight = !MoveRight;
        spriteRenderer.flipX = true;
        StartCoroutine(WaitToChangeDirectionBack());
    }
}
