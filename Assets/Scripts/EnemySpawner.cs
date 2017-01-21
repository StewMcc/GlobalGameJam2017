using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
[System.Serializable]
public class Spawning 
{
    [SerializeField]
    public GameObject spawningIteam;

    [SerializeField]
    public bool setToSpawn;

    public int sizeOfWave;

    [SerializeField]
    public float minTimeToSpawn;

    [SerializeField]
    public float maxTimeToSpawn;

    [HideInInspector]
    public float timer;

    [HideInInspector]
    public float delayOnSpawn; 

}

public class EnemySpawner : MonoBehaviour {


    [SerializeField]
    public List<Spawning> spawningItem;

    [SerializeField]
    private float sizeOfSpawnArea;

    [SerializeField]
    public float enemySpeed = 1.5f;

    [SerializeField]
    public float enemyScoreForKilling;

    [SerializeField]
    public float enemyDamange;

    public bool isSpawninging;


    private void Update()
    {
        if(isSpawninging)
        {
            foreach( Spawning spawn in spawningItem)
            {
                if (spawn.setToSpawn)
                {
                    if (spawn.sizeOfWave > 0)
                    {
                        if (spawn.timer < spawn.delayOnSpawn)
                        {
                            spawn.timer += Time.deltaTime;
                        }
                        else
                        {
                            spawn.timer = 0;

                            spawn.delayOnSpawn = SelecteRandomTimeToSpawn(spawn.minTimeToSpawn, spawn.maxTimeToSpawn);


                            GameObject enemy = Instantiate(spawn.spawningIteam, SelectRandomPosition(sizeOfSpawnArea), Quaternion.identity) as GameObject;

                            enemy.GetComponent<EnemyDeath>().scoreValue = enemyScoreForKilling;
                            enemy.GetComponent<EnemyDeath>().enemyDamage = enemyDamange;


                          //  enemy.GetComponent<NavMeshAgent>().speed = enemySpeed;
                            spawn.sizeOfWave--;
                        }
                    }
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sizeOfSpawnArea);
    }

    public float SelecteRandomTimeToSpawn(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    public Vector3 SelectRandomPosition(float sizeOfZone)
    {
        return transform.position  +  Random.insideUnitSphere * sizeOfZone;
    }
}
