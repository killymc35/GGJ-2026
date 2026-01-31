using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int hoursRemaining = 24;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI costText;
    
    public GameObject investigatePopup;
    
    public static TimeManager Instance;
    
    public BoardItem activator;

    private void Start()
    {
        Instance = this;
    }

    public void ShowInvestigatePopup(BoardItem activatingObject)
    {
        activator = activatingObject;
        var cost = activator.timeCost;
        
        ChangeCostText(cost);
        
        investigatePopup.SetActive(true);
    }

    private void ChangeCostText(int cost)
    {
        switch (cost) 
        {
            case 1:
                costText.text = "1 hour";
                break;
            case 3:
                costText.text = "3 hours";
                break;
            default:
                costText.text = "1 hour";
                break;
        }
    }
    
    public void SpendTime(int time)
    {
        hoursRemaining -= time;
    }

    private void Update()
    {
        timeText.text = hoursRemaining.ToString("00");
    }
}
