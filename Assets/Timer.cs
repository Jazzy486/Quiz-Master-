using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float TimeToCompleteQuestion = 30f;
    [SerializeField] float TimeToShowAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillAmount;
    
    float TimerValue;
    
    void Update()
    {
        TimerUpdate();  
    }

    void CancelTimer()
    {
        TimerValue = 0; 
    }

    void TimerUpdate()
    {
       
        TimerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(TimerValue > 0)
            {
                fillAmount = TimerValue/ TimeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion= false;
                TimerValue = TimeToShowAnswer;
            }
        }
        else
        {
            if(TimerValue > 0)
            {
                fillAmount = TimerValue / TimeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion= true;
                TimerValue = TimeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
        
        Debug.Log(isAnsweringQuestion + " = " + TimerValue + " = " + fillAmount);
    }

}
