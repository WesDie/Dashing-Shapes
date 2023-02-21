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

    bool kickback = false;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetMouseButtonDown(0)){
            Instantiate(bulletPrefab, posBullet.position, posBullet.rotation);
            body.AddForce(transform.right * 1000f);
            body.drag = 10f;
            float bulletKickbackTime = 0.5f;
            if(kickback == false){
                Invoke("cancelKickback", bulletKickbackTime);
            }
            kickback = true;
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        if(!kickback){
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            body.drag = 0f;
        }

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle -180, Vector3.forward);
    }

    void cancelKickback()
    {
        kickback = false;
    }
}
