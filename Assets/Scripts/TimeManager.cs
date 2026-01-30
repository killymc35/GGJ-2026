using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float hoursRemaining = 24;

    public void SpendTime(float time)
    {
        hoursRemaining -= time;
    }
}
