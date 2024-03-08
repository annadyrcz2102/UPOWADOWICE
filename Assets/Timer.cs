using System.Collections;
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

    public int Duration = 15;

    private float remainingDuration;

    private bool Pause;
    public bool IsSave;

    public GameObject player;
    public GameObject CheckPointPosition;


    private void Start()
    {
        remainingDuration = Duration;
        Pause = false;
        CheckPointPosition = GameObject.FindGameObjectWithTag("CheckPoint");
    }

    private void Update()
    {
        if(remainingDuration <= 0)
        {
            OnEnd();
            remainingDuration = Duration;
        }
    }

    private void FixedUpdate()
    {
        if (IsSave)
        {

                if (!Pause && remainingDuration >= 0 && remainingDuration < 15 || !Pause &&  remainingDuration <= 0 && remainingDuration < 15)
                {
                    uiText.text = $"{remainingDuration % 60:00}";
                   uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration += 1f * Time.deltaTime;
                }
        }
        else
        {
                if (!Pause && remainingDuration >= 0)
                {
                    uiText.text = $"{remainingDuration % 60:00}";
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration -= 1f * Time.deltaTime;
                }
        }
    }


    private void OnEnd()
    {
        player.transform.position = CheckPointPosition.transform.position;
    }
}
