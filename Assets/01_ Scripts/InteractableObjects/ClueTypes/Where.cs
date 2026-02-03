using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Where : Clue
{
    [Header("Clue Properties")] 
    public Ledger.WhereLocation place;
    public string info;

    [Header("UI Elements")] 
    public TextMeshProUGUI placeText;
    public RawImage placeImage;
    public TextMeshProUGUI infoText;

    [Header("Location Images")] 
    public Texture ballroom;
    public Texture courtyard;
    public Texture bedchambers;
    public Texture study;
    
    private void OnValidate()
    {
        RevealedSoundEffectName = "Investigation_Where";
        placeText.text = place.ToString();
        infoText.text = info;

        Texture locationImage = null;

        switch (place)
        {
            case Ledger.WhereLocation.Ballroom:
                locationImage = ballroom;
                break;
            case Ledger.WhereLocation.Courtyard:
                locationImage = courtyard;
                break;
            case Ledger.WhereLocation.Bedchambers:
                locationImage = bedchambers;
                break;
            case Ledger.WhereLocation.Study:
                locationImage = study;
                break;
        }

        placeImage.texture = locationImage;
    }
}
