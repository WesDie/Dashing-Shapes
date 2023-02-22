using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFirstRoom : MonoBehaviour
{
    public GameObject roomPrefab;
    GameObject roomsRoot;
    bool isactived = false;
    
    void Start(){
        roomsRoot = GameObject.FindGameObjectWithTag("CurrentRoomRoot").gameObject;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isactived)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if(roomsRoot.transform.childCount != 3){
                for (int i = 0; i < roomsRoot.transform.childCount - 1; i++)
                {
                    Destroy(roomsRoot.transform.GetChild(i).gameObject);
                }
                Vector2 roomNextPos1 = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 25);
                Instantiate(roomPrefab, roomNextPos1, Quaternion.identity, roomsRoot.transform);
                Vector2 roomNextPos2 = new Vector2(roomsRoot.transform.GetChild(0).transform.position.x, roomsRoot.transform.GetChild(0).transform.position.y + 35);
                Instantiate(roomPrefab, roomNextPos2, Quaternion.identity, roomsRoot.transform);
            }
        }
    }
}
