using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScale = 1f;
    [SerializeField] private float SlowDownScale = 0.5f;
    [SerializeField] private float SpeedUpScale = 2f;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SlowDownTime();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            SpeedUpTime();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            FreezeTime();
        }
    }

    private void SlowDownTime()
    {
        if(TimeScale == SlowDownScale)
        {
            TimeScale = 1f;
        }
        else
        {
            TimeScale = SlowDownScale;
        }
    }

    private void SpeedUpTime()
    {
        if(TimeScale == SpeedUpScale)
        {
            TimeScale = 1f;
        }
        else
        {
            TimeScale = SpeedUpScale;
        }
    }

    private void FreezeTime()
    {
        if(TimeScale == 0f)
        {
            TimeScale = 1f;
        }
        else
        {
            TimeScale = 0f;
        }
    }

}
