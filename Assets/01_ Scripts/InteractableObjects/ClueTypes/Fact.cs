using System;
using UnityEngine;
using TMPro;

public class Fact : Clue
{
    [Header("Clue Properties")]
    public string fact;
    
    [Header("UI Elements")]
    public TextMeshProUGUI factText;

    private void OnValidate()
    {
        factText.text = fact;
    }
}
