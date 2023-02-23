using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 target;
    public ParticleSystem shotExplosionFX;
    float distance;
    GameObject[] enemies;
    GameObject gunPos;
    public GameObject bulletEnemy;

    void Start(){
        gunPos = transform.GetChild(0).gameObject;
        Invoke("Shoot", Random.Range(0.3f, 0.8f));
    }


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        distance = Vector3.Distance(transform.position, target);

        Vector3 dir = new Vector3(target.x, target.y, 0) - gunPos.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        gunPos.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        if(distance > 4f){
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (currentDistance < 0.5f)
                {
                    Vector3 dist = transform.position - enemy.transform.position;
                    transform.position += dist;
                }
            }
        }
    }

    void Shoot(){
        Instantiate(bulletEnemy, gunPos.transform.position, Quaternion.Euler(gunPos.transform.eulerAngles.x, gunPos.transform.eulerAngles.y, gunPos.transform.eulerAngles.z - 90f));
        Invoke("Shoot", Random.Range(0.3f, 0.8f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet"){
            transform.parent.parent.GetComponent<LoadNextRoom>().Enemieskilled++;
            Instantiate(shotExplosionFX, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
