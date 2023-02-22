using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraArcade : MonoBehaviour
{
    private float shakeDuration = 0f;
    
    private float shakeMagnitude = 0.1f;
    
    private float dampingSpeed = 0.1f;
    
    Vector3 initialPosition;

    void Start(){
        initialPosition = new Vector3(0, 0f, -10f);
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition =  Vector3.Slerp(transform.position, initialPosition, 2f * Time.deltaTime);;
        }
    }

    public void TriggerShake() {
        shakeDuration = 0.02f;
    }
}
