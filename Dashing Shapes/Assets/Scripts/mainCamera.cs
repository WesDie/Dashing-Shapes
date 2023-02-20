using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    public float cameraSpeed;

    void Start(){
    }

    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }

    public void TriggerShake() {
        //shakeDuration = 0.02f;
    }
}
