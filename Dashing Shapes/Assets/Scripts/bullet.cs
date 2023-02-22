using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float speed = 20;
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * -speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
