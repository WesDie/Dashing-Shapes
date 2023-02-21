using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyRed;
    public GameObject enemyGreen;
    public GameObject enemyBlue;
    public float timeBetweenEnemies = 2f;
    private float spawnTime;
    public GameObject[] spawns;
    public float enemySpeed;
    public float enemySpeedMultiply = 0.0005f;
    public float enemySpawnMultiply = 0.05f;
    int enemiesSpawned;

    Manager gameManagerScript;


    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
    }


    void Update()
    {
        if(Time.time > spawnTime){
            Spawn();
            Spawn();
            gameManagerScript.score += 1;
            spawnTime = Time.time + timeBetweenEnemies;
        }
    }
    void Spawn(){
        int rand = Random.Range(0, spawns.Length);
        int enemyTypeRand = Random.Range(0, 100);

        if(enemyTypeRand <= 5 ){
            Instantiate(enemyGreen, transform.position + spawns[rand].transform.position, transform.rotation);
        } else if(enemyTypeRand == 11 ){
            Instantiate(enemyBlue, transform.position + spawns[rand].transform.position, transform.rotation);
        } else {
            Instantiate(enemyRed, transform.position + spawns[rand].transform.position, transform.rotation);
        }

        enemiesSpawned++;

        if(enemySpeed < 50f){
            enemySpeed = 10 + (enemiesSpawned * enemySpeedMultiply);
            if(timeBetweenEnemies > 0.5f){
                timeBetweenEnemies = 0.6f - (enemiesSpawned * enemySpawnMultiply);
            }
        }
    }
}
