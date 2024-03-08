using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SafeZone : MonoBehaviour
{
    Light2D light;
    float lightDefault;
    [SerializeField] float lightWhenIn;
    void Start()
    {
        light = GetComponent<Light2D>();
        lightDefault = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        light.pointLightOuterRadius = lightWhenIn;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        light.pointLightOuterRadius = lightDefault;
    }
}
