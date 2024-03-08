using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SafePlayer : MonoBehaviour
{
    public GameObject timer;
    public GameObject CheckPointPosition;
    public CircleCollider2D colider;
    public bool triggerlight;
    float lightDefault;
    Light2D light;


    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        CheckPointPosition = GameObject.FindGameObjectWithTag("CheckPoint");
        light = GetComponent<Light2D>();
        lightDefault = GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        if(triggerlight)
        {
            Invoke("OffLight", 3f);
            
        }

        if(light.pointLightOuterRadius <= 0)
        {
            colider.gameObject.SetActive(false);
        }

    }

    void OffLight()
    {
        if(light.pointLightOuterRadius > 0)
        light.pointLightOuterRadius -= 0.5f * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           timer.GetComponent<Timer>().IsSave = true;
           CheckPointPosition.transform.position = transform.position;
           triggerlight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           timer.GetComponent<Timer>().IsSave = false;
        }
    }

}
