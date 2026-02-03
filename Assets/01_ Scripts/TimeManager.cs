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
    public int activatorCost;

    private void Start()
    {
        Instance = this;

        AkUnitySoundEngine.PostEvent("Music_Level_1", gameObject);
    }

    public void ShowInvestigatePopup(BoardItem activatingObject)
    {
        

        activator = activatingObject;
        activatorCost = activator.timeCost;
        if (hoursRemaining < activatorCost) return;
        
        ChangeCostText(activatorCost);
        
        investigatePopup.SetActive(true);


        AkUnitySoundEngine.PostEvent("Board_Select", activatingObject.gameObject);
    }

    public void HideInvestigatePopup()
    {
        investigatePopup.SetActive(false);
    }

    public void ConfirmInvestigate()
    {
        investigatePopup.SetActive(false);
        SpendTime(activatorCost);
        /*activator.MarkAsRevealed();*/

        AkUnitySoundEngine.PostEvent("Music_Investigate", gameObject);
        if (hoursRemaining >= 9 && hoursRemaining <= 16)
        {
            AkUnitySoundEngine.PostEvent("Music_Level_2", gameObject);
        }
        else if (hoursRemaining >= 1 && hoursRemaining <= 8)
        {
            AkUnitySoundEngine.PostEvent("Music_Level_3", gameObject);
        }
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

        if (time <= 1)
        {
            AkUnitySoundEngine.PostEvent("Clock_Speed_1", gameObject);
        }
        else if (time == 2)
        {
            AkUnitySoundEngine.PostEvent("Clock_Speed_2", gameObject);
        }
        else if (time >= 3)
        {
            AkUnitySoundEngine.PostEvent("Clock_Speed_3", gameObject);
        }
    }

    private void Update()
    {
        timeText.text = hoursRemaining.ToString("00");
    }
}
