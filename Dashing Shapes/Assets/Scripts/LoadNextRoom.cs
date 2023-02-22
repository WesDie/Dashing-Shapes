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

    void Start(){
        roomsRoot = GameObject.FindGameObjectWithTag("CurrentRoomRoot").gameObject;
    }

    void Update(){
        if(Enemieskilled >= enemiesInRoom){
            transform.GetChild(1).gameObject.SetActive(false);
        } else {
            transform.GetChild(1).gameObject.SetActive(true);
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
                transform.GetChild(0).GetChild(i).GetComponent<Enemy>().enabled = true;
                enemiesInRoom++;
            }
            if(roomsRoot.transform.childCount == 4){
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 40);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
                Debug.Log("Load room 4");
            }
            else if(roomsRoot.transform.childCount == 5){
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 50);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
                Debug.Log("Load room 5");
            } else if(roomsRoot.transform.childCount == 6){
                Debug.Log("Load room and destroy first");
                Destroy(roomsRoot.transform.GetChild(0).gameObject);
                Vector2 roomNextPos = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 60);
                Instantiate(roomPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
            }
        }
    }
}
