using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float speed;
    public enum enmeyType
    {
        red, 
        green, 
        blue
    }

    public enmeyType selectedEnemyType;
    Image healthbar;    
    mainCamera cameraScript;
    EnemySpawn enemySpawnScript;
    void Start(){
        enemySpawnScript = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawn>();
        speed = enemySpawnScript.enemySpeed;
        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>();
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(selectedEnemyType == enmeyType.red){
                Debug.Log("Remove Health!");
                cameraScript.TriggerShake();
                healthbar.fillAmount -= 0.2f;
                Destroy(gameObject);
            } else if(selectedEnemyType == enmeyType.green){
                Debug.Log("Add Health!");
                cameraScript.TriggerShake();
                other.gameObject.GetComponent<movement>().valueTimed = 10;
                other.gameObject.GetComponent<movement>().FastShooting();
                Destroy(gameObject);
            } else if(selectedEnemyType == enmeyType.blue){
                Debug.Log("Game over!");
                cameraScript.TriggerShake();
                healthbar.fillAmount += 0.2f;
                Destroy(gameObject);
            }
        }
    }
}
