using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum enmeyType
    {
        red, 
        green, 
        blue
    }

    public enmeyType selectedEnemyType;
    Image healthbar;    
    mainCamera cameraScript;
    void Start(){
        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>();
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(selectedEnemyType == enmeyType.red){
                Debug.Log("Remove Health!");
                cameraScript.TriggerShake();
                healthbar.fillAmount -= 0.2f;
                Destroy(gameObject);
            } else if(selectedEnemyType == enmeyType.green){
                Debug.Log("Add Health!");
                cameraScript.TriggerShake();
                healthbar.fillAmount += 0.2f;
                Destroy(gameObject);
            } else if(selectedEnemyType == enmeyType.blue){
                Debug.Log("Game over!");
                cameraScript.TriggerShake();
                healthbar.fillAmount -= 1f;
                Destroy(gameObject);
            }
        }
    }
}
