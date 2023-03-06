using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBulletEnemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 target;
    public float explosionDistance = 2f;
    private Animator anim;
    bool exploding = false;
    public ParticleSystem explosionFX;
    public ParticleSystem shotExplosionFX;
    public float distance;
    GameObject[] enemies;
    public GameObject projectile;

    void Start(){
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        distance = Vector3.Distance(transform.position, target);

        if(distance < explosionDistance || exploding){
            if(!exploding){
                Invoke("explode", 1f);
            }
            exploding = true;
            anim.Play("Explode");
            //return;
        } else {
            anim.Play("Normal");
        }

        if(distance > 1.5f){
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

    void explode()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().TriggerShake();
        for (int i = 0; i < 18; i++)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + (i * 20)));
        }
        exploding = false;
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
