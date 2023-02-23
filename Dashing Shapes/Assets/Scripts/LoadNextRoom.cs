using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextRoom : MonoBehaviour
{
    public GameObject roomPrefab;
    GameObject roomsRoot;
    public int Enemieskilled = 0;
    public int enemiesInRoom;
    bool isactived = false;
    bool roomCleared = false;
    public GameObject EnemyType;
    public Transform[] spawns;
    public float changeOfEnemySpawn;
    public enum enemyType
    {
        ExplodingEnemy, 
        ShootingEnemy
    }
    public enemyType selectedEnemyType;

    void Start(){
        roomsRoot = GameObject.FindGameObjectWithTag("CurrentRoomRoot").gameObject;
        for (int i = 0; i < spawns.Length; i++)
        {
            if(Random.Range(0, 10) > changeOfEnemySpawn){
                Instantiate(EnemyType, spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity, transform.GetChild(0).transform);
            }
        }
    }

    void Update(){
        if(Enemieskilled >= enemiesInRoom){
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        } else {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            if(!roomCleared){
                roomCleared = true;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<managerGame>().roomsCleared++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isactived)
        {
            isactived = true;
            transform.GetChild(2).gameObject.SetActive(true);
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                if(selectedEnemyType == enemyType.ExplodingEnemy){
                    transform.GetChild(0).GetChild(i).GetComponent<Enemy>().enabled = true;
                } else if(selectedEnemyType == enemyType.ShootingEnemy){
                    transform.GetChild(0).GetChild(i).GetComponent<ShootingEnemy>().enabled = true;
                }
                enemiesInRoom++;
            }
            if(roomsRoot.transform.childCount == 3){
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 30);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
                Debug.Log("Load room 3");
            }
            else if(roomsRoot.transform.childCount == 4){
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 40);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
                Debug.Log("Load room 4");
            } else if(roomsRoot.transform.childCount == 5){
                Debug.Log("Load room and destroy first");
                Destroy(roomsRoot.transform.GetChild(0).gameObject);
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 50);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
            }
        }
    }
}
