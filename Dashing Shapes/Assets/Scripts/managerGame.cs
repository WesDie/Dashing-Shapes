using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class managerGame : MonoBehaviour
{
    public int roomsCleared = -1;
    GameObject roomsClearedtext;
    void Start()
    {
        roomsClearedtext = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if(roomsCleared != -1){
            roomsClearedtext.GetComponent<TMP_Text>().text = "Rooms cleared: " + roomsCleared.ToString();
        }
    }
}
