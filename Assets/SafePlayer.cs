using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePlayer : MonoBehaviour
{
    public GameObject timer;
    public GameObject CheckPointPosition;


    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        CheckPointPosition = GameObject.FindGameObjectWithTag("CheckPoint");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           timer.GetComponent<Timer>().IsSave = true;
           CheckPointPosition.transform.position = transform.position;
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
