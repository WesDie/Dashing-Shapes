using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;
    public bool isEnemyBullet = false;
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
        if (other.tag == "Player" && isEnemyBullet == true)
        {
            other.GetComponent<player>().Health--;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().TriggerShake();
        }
    }
}
