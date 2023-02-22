using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
                Invoke("explode", 2.5f);
            }
            exploding = true;
            anim.Play("Explode");
            //return;
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
        if(distance < 3f){
            Transform targetExplosion = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector2 direction =  targetExplosion.position - transform.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(direction * 1500f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().drag = 10f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().kickback = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().Health -= 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().Invoke("cancelKickback", 0.5f);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().TriggerShake();
        }
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (currentDistance < 2f)
                {
                    Instantiate(explosionFX, enemy.transform.position, Quaternion.identity);
                    transform.parent.parent.GetComponent<LoadNextRoom>().Enemieskilled++;
                    Destroy(enemy);
                }
            }
        }
        transform.parent.parent.GetComponent<LoadNextRoom>().Enemieskilled++;
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
