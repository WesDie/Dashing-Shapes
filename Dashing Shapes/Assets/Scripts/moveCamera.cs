using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    bool isDone;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isDone)
        {
            isDone = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().newCameraPos(new Vector3(transform.position.x, transform.position.y, -10f));
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().isInBeginArea = false;
        }
    }
}
