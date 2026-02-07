using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class When : Clue
{
    [Header("Clue Properties")]
    public Ledger.WhenTime time;
    public string info;
    
    [Header("UI Elements")]
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI infoText;

    private void OnValidate()
    {
        timeText.text = time.ToString();
        infoText.text = info;
    }

    private void Start()
    {
        RevealedSoundEffectName = "Investigation_When";
    }
}
