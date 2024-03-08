using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SafeZone : MonoBehaviour
{
    Light2D light;
    float lightDefault;
    [SerializeField] float lightWhenIn;
    public bool inside;

    void Start()
    {
        light = GetComponent<Light2D>();
        lightDefault = GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        if(inside && light.pointLightOuterRadius < lightWhenIn)
        {
            light.pointLightOuterRadius += 3f * Time.deltaTime;
            GetComponent<CircleCollider2D>().radius = light.pointLightOuterRadius;
        }
        else if(!inside && light.pointLightOuterRadius > lightDefault)
        {
            light.pointLightOuterRadius -= 2.5f * Time.deltaTime;
            GetComponent<CircleCollider2D>().radius = light.pointLightOuterRadius;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }
}
