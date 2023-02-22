using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    bool isDone;
    public bool isExitRoom = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isDone)
        {
            isDone = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().newCameraPos(new Vector3(transform.position.x, transform.position.y, -10f));
            if(!isExitRoom){
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(6.5f, 5f, 1f, 100f));
            } else{
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(5f, 6.5f, 1f, 100f));
            }
        }
    }
}
