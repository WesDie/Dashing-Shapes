using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    private Vector2 target;
    public float distance;
    bool playerIsInMenu;

    void Update(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        distance = Vector3.Distance(transform.position, target);

        if(distance < 10f && playerIsInMenu == false){
            float alphaColor = 1f - (distance / 10);
            if(alphaColor < 1f && alphaColor > 0.2f){
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, alphaColor);
            }
        }

        if(distance < 1f){
            if(Input.GetKeyDown(KeyCode.E)){
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().newCameraPos(new Vector3(transform.position.x, transform.position.y, -10f));
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mainCamera>().ZoomCamera(6.5f, 2.5f, 1f, 100f));
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().enabled = false;
                playerIsInMenu = true;
                StartCoroutine(ChangeCirlceAlpha(1f, 0f, 3f, 100f));
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(ChangeUIAlpha(0f, 1f, 3f, 100f));
            }
        }
        if(playerIsInMenu == true){
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = Vector3.Slerp(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), 2f * Time.deltaTime);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation = Quaternion.Slerp(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation, Quaternion.Euler(0, 0, -90), 2f * Time.deltaTime);
        }
    }

    public IEnumerator ChangeCirlceAlpha(float from, float to, float time, float steps)
    {
        float f = 0;
 
        while (f <= 1)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, Mathf.Lerp(from, to, f));
 
            f += 1f/steps;
 
            yield return new WaitForSeconds(time/steps);
        }
    }
    public IEnumerator ChangeUIAlpha(float from, float to, float time, float steps)
    {
        float f = 0;
 
        while (f <= 1)
        {
            transform.GetChild(0).GetComponent<Image>().color = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, Mathf.Lerp(from, to, f));
            transform.GetChild(1).GetComponent<Image>().color = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, Mathf.Lerp(from, to, f));

            f += 1f/steps;
 
            yield return new WaitForSeconds(time/steps);
        }
    }
}
