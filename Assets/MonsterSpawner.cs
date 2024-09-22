using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public float[] spawnProbabilities;
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;
    private float minSpawnInterval = 0.5f;

    public Statistic statistic;

    private void Start()
    {
        GameObject otherObject = GameObject.Find("Stats");
        statistic = otherObject.GetComponent<Statistic>();
        statistic.spawnInterval = spawnInterval;
        StartCoroutine(SpawnMonsters());
        StartCoroutine(UpdateSpawnInterval());
    }

    private void Update() {
        statistic.spawnInterval = spawnInterval;
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            GameObject monsterToSpawn = ChooseMonster();

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(monsterToSpawn, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private GameObject ChooseMonster()
    {
        float randomValue = Random.value; 
        float cumulativeProbability = 0f;

        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            cumulativeProbability += spawnProbabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return monsterPrefabs[i];
            }
        }

        return monsterPrefabs[0]; 
    }

    private IEnumerator UpdateSpawnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); 
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.1f); 
        }
    }
}
