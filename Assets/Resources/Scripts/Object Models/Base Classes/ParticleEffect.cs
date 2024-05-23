public class ParticleEffect : TimedObject
{
    protected new void Awake()
    {
        SecondsUntilDeath = 2f;
        base.Awake();
    }
    
}
