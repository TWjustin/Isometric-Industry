using System.Collections;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnDayChanged;
    public static Action OnMonthChanged;
    
    public static int Day { get; private set; }
    public static int Month { get; private set; }
    
    public float dayToRealTime = 0.5f;
    private float timer;
    
    void Start()
    {
        Day = 1;
        Month = 1;
        timer = dayToRealTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Day++;
            if (Day > 30)
            {
                Day = 1;
                Month++;
                OnMonthChanged?.Invoke();
            }
            OnDayChanged?.Invoke();
            timer = dayToRealTime;
        }
    }
}
