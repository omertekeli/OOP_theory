using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animalPrefabs;

 
    private readonly float zPos = 8.6f;
    private readonly float xPos = 4.7f;
    private readonly float yPos = 1.7f;

    private int waveNumber = 1;
    private int animalCount;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        animalCount = FindObjectsOfType<Animal>().Length;

        if (animalCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int animalsToSpawn)
    {
        for (int i = 0; i < animalsToSpawn; i++)
        {
            int index = Random.Range(0, animalPrefabs.Count);
            Instantiate(animalPrefabs[index], GenerateSpawnPosition(), animalPrefabs[index].transform.rotation);
        }
        
    }

    Vector3 GenerateSpawnPosition()
    { 
        Vector3 spawnPos = new Vector3(Random.Range(-xPos, xPos), -yPos, Random.Range(-zPos, zPos));
        return spawnPos;
    }
}
