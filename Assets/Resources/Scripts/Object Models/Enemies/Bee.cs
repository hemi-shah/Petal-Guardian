using UnityEngine;
using UnityEngine.Serialization;

public class Bee : Enemy
{
    [FormerlySerializedAs("beeHealth")] [SerializeField] private float BeeHealth = 5f;
    [FormerlySerializedAs("beeDamage")] [SerializeField] private float BeeDamage = 5f;
    private float initialYPosition;
    private float maxYMovement = 0.06f;
    private float floatAmplitude = 2.5f;
    [FormerlySerializedAs("floatFrequency")] [SerializeField]
    private float FloatFrequency = 1f;
    private float startTime;
    public int PointsWorth = 5;

    protected new void Awake()
    {
        base.Awake();
        initialYPosition = transform.position.y;
        startTime = Time.time;
        PointsToGain = PointsWorth;
    }

    protected new void Start()
    {
        MaxHealth = BeeHealth * Game.Difficulty;
        DamageToDeal = BeeDamage * Game.Difficulty;
        base.Start();
    }

    protected override void Move()
    {
        var yOffset = Mathf.Sin((Time.time - startTime) * FloatFrequency) * floatAmplitude;
        var newYPos = Mathf.Clamp((transform.position.y + yOffset), -maxYMovement+initialYPosition, maxYMovement+initialYPosition);
        var newXPos = MoveRight ? (Game.LeftEdgeOfScreenXPos*-1) : (Game.LeftEdgeOfScreenXPos); //MOVE RIGHT CODE
        var targetPosition = new Vector2(newXPos, newYPos);
        var newPosition = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
        transform.position = newPosition;
    }
    
}