using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePlayer : MonoBehaviour
{
    public GameObject timer;


    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           timer.GetComponent<Timer>().IsSave = true;
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
