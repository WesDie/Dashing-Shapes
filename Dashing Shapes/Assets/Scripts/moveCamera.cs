using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public bool isExitRoom = false;
    public bool isInExit = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameObject.FindGameObjectWithTag("GameManager").GetComponent<managerGame>().isInCharMenu == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().newCameraPos(new Vector3(transform.position.x, transform.position.y, -10f));
            if(!isExitRoom && !isInExit){
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(6.5f, 5f, 1f, 100f));
            } else if(isExitRoom && !isInExit){
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(5f, 6.5f, 1f, 100f));
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void ZoomCam(){
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().newCameraPos(new Vector3(transform.position.x, transform.position.y, -10f));
        if(!isExitRoom && !isInExit){
            StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(6.5f, 2.5f, 1f, 100f));
        } else if(isExitRoom && !isInExit){
            StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(2.5f, 6.5f, 1f, 100f));
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
