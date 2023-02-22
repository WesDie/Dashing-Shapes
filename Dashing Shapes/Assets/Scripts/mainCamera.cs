using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    private float shakeDuration = 0f;
    
    private float shakeMagnitude = 0.1f;
    
    private float dampingSpeed = 0.1f;
    
    Vector3 initialPosition;
    public bool isInBeginArea = true;

    void Start()
    {
        initialPosition = new Vector3(0, -10f, -10f);;
    }

    void Update()
    {
        if(isInBeginArea){
            transform.localPosition =  Vector3.Slerp(transform.position, new Vector3(-0.21f, -11.14f, -10f), 2f * Time.deltaTime);;
            GetComponent<Camera>().orthographicSize = 6.6f;
        } else if (shakeDuration > 0)
        {
            GetComponent<Camera>().orthographicSize = 5f;
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            GetComponent<Camera>().orthographicSize = 5f;
            shakeDuration = 0f;
            transform.localPosition =  Vector3.Slerp(transform.position, initialPosition, 2f * Time.deltaTime);;
        }
    }

    public void TriggerShake() {
        shakeDuration = 0.02f;
    }

    public void newCameraPos(Vector3 pos){
        initialPosition = pos;
    }
}
