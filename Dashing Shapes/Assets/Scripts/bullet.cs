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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other);
        }

        if (other.tag == "Wall")
        {
            Debug.Log("Hit wall");
            Destroy(gameObject);
        }
    }
}
