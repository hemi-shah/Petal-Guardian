using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEnemies : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public List<Transform> Lanes;
    public int NumberOfEnemies = 10;

    // Start is called before the first frame update
    private void Start()
    {
        // SpawnEnemies(NumberOfEnemies);  
    }

    public void SpawnEnemies(int numberOfEnemiesToSpawn)
    {
        StartCoroutine(SpawnMultipleEnemies(numberOfEnemiesToSpawn));
    }

    private IEnumerator SpawnMultipleEnemies(int numberOfEnemiesToSpawn)
    {
        for (var i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            var selectedEnemyPrefab = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)];

            var laneIndex = Random.Range(0, Lanes.Count - 1);
            print("Spawned in lane " + laneIndex);
            var spawnY = Lanes[laneIndex].position.y+3.37f;
            var spawnX = 10f;  

            var spawnPosition = new Vector3(spawnX, spawnY, 0f);

            var enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);

            var randomSpawnRate = Random.Range(5f, 10f);
            yield return new WaitForSeconds(randomSpawnRate);
        }
    }

    public void SpawnOneEnemy(GameObject enemy)
    {
        var laneIndex = Random.Range(0, Lanes.Count - 1);
        var spawnY = Lanes[laneIndex].position.y+3.37f;
        var spawnX = 10f;
        var spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
