using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> ballPrefabs;

 
    private readonly float zPos = 8.6f;
    private readonly float xPos = 4.7f;
    private readonly float yPos = 1.5f;

    private int ballCount;

    //Encapsulation example
    private int _waveNumber = 1;
    public int waveNumber { 
        
        get { return _waveNumber; }

        set
        {
            if (value < 1)
            {
                Debug.LogError("Please set this value as positive number");
            }
            else
            {
                _waveNumber = value;
            }
        } 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(_waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        ballCount = FindObjectsOfType<Ball>().Length;

        if (ballCount == 0)
        {
            _waveNumber++;
            SpawnEnemyWave(_waveNumber);
        }
    }
    

    /*Below two methods can run in update method, but this not clean code.
    To ensure that I applied abstraction theory*/
    void SpawnEnemyWave(int ballsToSpawn)
    {
        for (int i = 0; i < ballsToSpawn; i++)
        {
            int index = Random.Range(0, ballPrefabs.Count);
            Instantiate(ballPrefabs[index], GenerateSpawnPosition(), ballPrefabs[index].transform.rotation);
        }
        
    }

    Vector3 GenerateSpawnPosition()
    { 
        Vector3 spawnPos = new Vector3(Random.Range(-xPos, xPos), -yPos, Random.Range(-zPos, zPos));
        return spawnPos;
    }
}
