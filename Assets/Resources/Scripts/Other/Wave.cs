using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public List<GameObject> Enemies;
    public int Count;
    public Wave(List<GameObject> enemies)
    {
        Enemies = enemies;
        Count = enemies.Count;
    }

    public GameObject GetEnemyToSpawn()
    {
        Count--;
        var returnValue = Enemies[0];
        Enemies.RemoveAt(0);
        return returnValue;
    }
}
