using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductTimer : MonoBehaviour
{
    private bool inProgress;
    private DateTime TimerStart;
    private DateTime TimerEnd;
    
    private Coroutine lastTimer;
    private Coroutine lastDisplay;
    
    [Header("Production Time")]
    public int Hours;
    public int Minutes;
    public int Seconds;
    
    [Header("UI")]
    [SerializeField] private GameObject timerUI;
    [SerializeField] private Slider timeLeftSlider;
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Button skipButton;
    
    // 我寫的
    public FarmingSO farmingSO;
    

    #region UI Methods

    private void InitializeWindow()
    {
        if (inProgress)
        {
            lastDisplay = StartCoroutine(DisplayTime());
            skipButton.gameObject.SetActive(true);
        }
        else
        {
            //
        }
        
    }

    private IEnumerator DisplayTime()
    {
        DateTime start = DateTime.Now;
        TimeSpan timeLeft = TimerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (TimerEnd - TimerStart).TotalSeconds;
        string text;

        while (timerUI.activeSelf)
        {
            text = "";
            timeLeftSlider.value = Convert.ToSingle(totalSecondsLeft / totalSeconds);
            if (totalSecondsLeft > 1)
            {
                if (timeLeft.Hours != 0)
                {
                    text += timeLeft.Hours + "h ";
                    text += timeLeft.Minutes + "m ";
                    yield return new WaitForSeconds(timeLeft.Seconds);
                }
                else if (timeLeft.Minutes != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Minutes + "m ";
                    text += ts.Seconds + "s ";
                }
                else
                {
                    text += Mathf.FloorToInt((float)totalSecondsLeft) + "s";
                }
                
                timeLeftText.text = text;

                totalSecondsLeft -= Time.deltaTime;
                yield return null;
            }
            else
            {
                timeLeftText.text = "Finished";
                skipButton.gameObject.SetActive(false);
                inProgress = false;
                break;
            }
        }
        
        yield return null;
    }

    public void OpenWindow()
    {
        timerUI.SetActive(true);
        InitializeWindow();
    }
    
    public void CloseWindow()
    {
        timerUI.SetActive(false);
    }

    #endregion

    #region Timed Event

    private void StartTimer()
    {
        TimerStart = DateTime.Now;
        TimeSpan time = new TimeSpan(Hours, Minutes, Seconds);
        TimerEnd = TimerStart.Add(time);
        inProgress = true;

        lastTimer = StartCoroutine(Timer());
        
        InitializeWindow();
    }

    private IEnumerator Timer()
    {
        DateTime start = DateTime.Now;
        double secondsToFinnish = (TimerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinnish));
        
        inProgress = false;
        Debug.Log("Finished");
    }

    private void Skip()
    {
        TimerEnd = DateTime.Now;
        inProgress = false;
        StopCoroutine(lastTimer);
        
        timeLeftText.text = "Finished";
        timeLeftSlider.value = 1;
        
        StopCoroutine(lastDisplay);
        skipButton.gameObject.SetActive(false);
    }

    #endregion
}
