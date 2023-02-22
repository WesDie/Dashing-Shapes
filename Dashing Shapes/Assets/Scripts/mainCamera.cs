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
        initialPosition = new Vector3(0, -10f, -10f);
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

    public IEnumerator ZoomCamera(float from, float to, float time, float steps)
    {
        float f = 0;
 
        while (f <= 1)
        {
            Camera.main.orthographicSize = Mathf.Lerp(from, to, f);
 
            f += 1f/steps;
 
            yield return new WaitForSeconds(time/steps);
        }
    }

    public void TriggerShake() {
        shakeDuration = 0.02f;
    }

    public void newCameraPos(Vector3 pos){
        initialPosition = pos;
    }
}
