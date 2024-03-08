using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killable : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] Slider slider;
    void Start()
    {
        slider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        slider.value = health;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
