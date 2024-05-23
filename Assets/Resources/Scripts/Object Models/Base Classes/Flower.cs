public class Flower : HealthObject
{
    protected new void Awake()
    {
        ObjectType = ObjectType.Flower;
        base.Awake();
        MaxHealth = 5;
        HealToMax();
    }

}
