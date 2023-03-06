using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadExitRoom : MonoBehaviour
{
    bool isactived = false;
    public GameObject roomExitPrefab;
    GameObject roomsRoot;

    void Start(){
        roomsRoot = GameObject.FindGameObjectWithTag("CurrentRoomRoot").gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isactived)
        {
            Vector2 roomNextPos = new Vector2(transform.position.x + 23.65f, transform.position.y + 5.62f);
            Instantiate(roomExitPrefab, roomNextPos, Quaternion.identity, roomsRoot.transform);
        }
    }
}
