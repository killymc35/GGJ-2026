using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int hoursRemaining = 24;
    public TextMeshProUGUI timeText;

    public void SpendTime(int time)
    {
        hoursRemaining -= time;
    }

    private void Update()
    {
        timeText.text = hoursRemaining.ToString("00");
    }
}
