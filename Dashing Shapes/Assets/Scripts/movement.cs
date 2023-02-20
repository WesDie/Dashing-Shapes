using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    float vertical;
    public float speed;
    Rigidbody2D body;

    public float health = 100;
    Image healthbar;   
    GameObject gameOverObject;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        gameOverObject = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        gameOverObject.SetActive(false);
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
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(body.velocity.x, vertical * speed);
    }
}
