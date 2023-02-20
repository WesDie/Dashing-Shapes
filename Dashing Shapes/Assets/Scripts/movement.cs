using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed;
    public float increment;
    public float maxY;
    public float minY;
    private Vector2 targetPos;

    public float health = 100;
    Image healthbar;   
    GameObject gameOverObject;
    public int valueTimed;

    public GameObject projectilePrefab;
    void Start()
    {
        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        gameOverObject = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        gameOverObject.SetActive(false);
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }


    void Update()
    {
        health = healthbar.fillAmount;
        if(health <= 0){
            gameObject.SetActive(false);
            Time.timeScale = 0;
            gameOverObject.SetActive(true);
            //Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxY) {
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minY) {
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }


    public void FastShooting(){
            if(valueTimed != 0){
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                valueTimed--;
                Invoke("FastShooting", 0.15f);
            }
    }
}
