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

    private void Start()
    {
        remainingDuration = Duration;
        Pause = false;
    }



    private void FixedUpdate()
    {
        if (IsSave)
        {

                if (!Pause && remainingDuration >= 0 && remainingDuration < 15)
                {
                    uiText.text = $"{remainingDuration % 60:00}";
                   uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration += 1f * Time.deltaTime;
                   Debug.Log("Safe");
                }



        }
        else
        {

                if (!Pause && remainingDuration >= 0)
                {
                    uiText.text = $"{remainingDuration % 60:00}";
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration -= 1f * Time.deltaTime;
                    Debug.Log("NotSafe");
                }
            
            OnEnd();

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

    }
}
