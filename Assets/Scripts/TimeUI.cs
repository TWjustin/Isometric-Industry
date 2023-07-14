using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public Text timeText;

    private void OnEnable()
    {
        TimeManager.OnDayChanged += UpdateTime;
        TimeManager.OnMonthChanged += UpdateTime;
    }
    
    private void OnDisable()
    {
        TimeManager.OnDayChanged -= UpdateTime;
        TimeManager.OnMonthChanged -= UpdateTime;
    }
    
    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.Month}月{TimeManager.Day}日";
    }
}
