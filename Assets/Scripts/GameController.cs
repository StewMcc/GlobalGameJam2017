using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class WaveSettings
{
    public float enemySpeedMultiplier = 1.2f;

    public int increaseOfEnemies = 1;

    public float enemyScoreMultiplier = 1.4f;

}

public class GameController : MonoBehaviour
{
    [SerializeField]
    Text waveText;
    [SerializeField]
    WaveSettings waveSettings;
    [SerializeField]
    private int maxNumberOfMetalIteamsInMap;

    private int numberOfMetalInMap;

    public int waveNumber = 0;

    private float timeSinceWaveEnd;
    [SerializeField]
    private int waveEnemies;
    
    [SerializeField]
    private float timeBetweenWave;

    [SerializeField]
    private float scoreForKillingEnemy;

    [SerializeField]
    private float speedOfEnemies;

    [SerializeField]
    private EnemySpawner enemySpawners;

    public static int numberOfEnemiesLeft = 0;

    private void Start()
    {
        // check how many metal iteams in map
        numberOfMetalInMap = GameObject.FindObjectsOfType<MetalObject>().Length;
    }

    private void Update()
    {
        waveText.text = "Wave: " + waveNumber.ToString("F0");

        if (numberOfMetalInMap < maxNumberOfMetalIteamsInMap)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("MetalSpawner");

            GameObject spawer = spawners[Random.Range(0, GameObject.FindGameObjectsWithTag("MetalSpawner").Length)];

            spawer.GetComponent<EnemySpawner>().isSpawninging = true;

            Spawning spawning = spawer.GetComponent<EnemySpawner>().spawningItem[Random.Range(0, spawer.GetComponent<EnemySpawner>().spawningItem.Count)];

            spawning.sizeOfWave = 1;
            numberOfMetalInMap++;
        } else
        {
            numberOfMetalInMap = GameObject.FindObjectsOfType<MetalObject>().Length;

        }

        if(numberOfEnemiesLeft >= 0)
        {
            if(timeSinceWaveEnd > timeBetweenWave)
            {
                timeSinceWaveEnd = 0;

                SpawnWave();

             }
            else
            {
                timeSinceWaveEnd += Time.deltaTime;
            }
        }

 
    }

    private void SpawnWave()
    {
        scoreForKillingEnemy *= waveSettings.enemyScoreMultiplier;


        numberOfEnemiesLeft = waveEnemies;
        waveNumber++;
        enemySpawners.enemyScoreForKilling = scoreForKillingEnemy;
         
       speedOfEnemies *= waveSettings.enemySpeedMultiplier;
        waveEnemies += waveSettings.increaseOfEnemies;
        enemySpawners.spawningItem[0].setToSpawn = true;
        enemySpawners.spawningItem[0].sizeOfWave = waveEnemies;
        //enemySpawners.enemySpeed = speedOfEnemies;

    }
}
