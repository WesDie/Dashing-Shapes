using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;
    public GameObject bulletPrefab;
    public Transform posBullet;
    public bool kickback = false;
    public int Health = 4;
    GameObject HealthBarObject;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        HealthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle -180);

        if(Input.GetKeyDown(KeyCode.P)){
            Time.timeScale = 0;
        }

        if (Input.GetMouseButtonDown(0)){
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().TriggerShake();
            Instantiate(bulletPrefab, posBullet.position, posBullet.rotation);
            body.AddForce(transform.right * 750f);
            body.drag = 10f;
            float bulletKickbackTime = 0.1f;
            if(kickback == false){
                Invoke("cancelKickback", bulletKickbackTime);
            }
            kickback = true;
        }
        if(Health == 4){
            HealthBarObject.transform.GetChild(0).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(1).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(2).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(3).gameObject.SetActive(true);
        } else if(Health == 3){
            HealthBarObject.transform.GetChild(0).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(1).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(2).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(3).gameObject.SetActive(false);
        } else if(Health == 2){
            HealthBarObject.transform.GetChild(0).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(1).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(2).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(3).gameObject.SetActive(false);
        } else if(Health == 1){
            HealthBarObject.transform.GetChild(0).gameObject.SetActive(true);
            HealthBarObject.transform.GetChild(1).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(2).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(3).gameObject.SetActive(false);
        }else if(Health == 0){
            HealthBarObject.transform.GetChild(0).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(1).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(2).gameObject.SetActive(false);
            HealthBarObject.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        if(!kickback){
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            body.drag = 0f;
        }
    }

    void cancelKickback()
    {
        kickback = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyBullet"){
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().TriggerShake();
            Destroy(other.gameObject);
            Health--;
        }
    }
}
