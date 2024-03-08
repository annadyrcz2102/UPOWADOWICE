﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int Duration;

    private float remainingDuration;

    private bool Pause;
    public bool IsSave;

    private void Start()
    {
        Begin(Duration);
    }

    private void Begin(float second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    private bool isTimerRunning = false;

    private void Update()
    {
        if (IsSave)
        {
            StopCoroutine(UpdateTimer());
            if(remainingDuration < 15)
            {
                remainingDuration += 0.01f;
                uiText.text = $"{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            }
            isTimerRunning = false;
        }
        else if (!isTimerRunning)
        {
            StartCoroutine(UpdateTimer());
            isTimerRunning = true;
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            yield return null;
        }
        OnEnd();
    }


    private void OnEnd()
    {
        Debug.Log("End");
    }
}
