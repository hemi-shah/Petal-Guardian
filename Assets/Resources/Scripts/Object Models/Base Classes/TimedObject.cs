using UnityEngine;

public class TimedObject : MonoBehaviour
{
    [SerializeField] protected float SecondsUntilDeath = 3;

    protected void Awake()
    {
        Destroy(gameObject, SecondsUntilDeath);
    }
}
