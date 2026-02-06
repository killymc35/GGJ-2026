using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Who : Clue
{
    [Header("Clue Properties")]
    public WhoCharacter character;
    private Character characterDetails;
    
    [Header("UI Elements")]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterDescription;
    public TextMeshProUGUI characterWeapon;
    public RawImage characterPortrait;
    public TextMeshProUGUI dialogueBox;
    public TMP_Dropdown dropdown;
    
    [Header("Character Portraits")] 
    public Texture green;
    public Texture purple;
    public Texture black;
    public Texture yellow;

    private void OnValidate()
    {
        RevealedSoundEffectName = "Investigation_Who";

        characterDetails = GetCharacterDetails(character);

        characterName.text = characterDetails.name;
        characterDescription.text = characterDetails.description;
        characterWeapon.text = characterDetails.weapon;

        switch (characterDetails.name)
        {
            case "Green":
                characterPortrait.texture = green;
                break;
            case "Purple":
                characterPortrait.texture = purple;
                break;
            case "Black":
                characterPortrait.texture = black;
                break;
            case "Yellow":
                characterPortrait.texture = yellow;
                break;
        }
    }

    public enum WhoCharacter
    {
    Green,
    Purple,
    Black,
    Yellow
    }
    
    [Serializable]
    public struct Character : IEquatable<Character>
    {
        public string name;
        public string description;
        public string weapon;
        public string dialogue1;
        public string dialogue2;
        public int dialogueProgress;

        public Character(string name, string description, string weapon, string dialogue1, string dialogue2, int dialogueProgress)
        {
            this.name = name;
            this.description = description;
            this.weapon = weapon;
            this.dialogue1 = dialogue1;
            this.dialogue2 = dialogue2;
            this.dialogueProgress = dialogueProgress;
        }

        public bool Equals(Character other)
        {
            return name == other.name && description == other.description && weapon == other.weapon && dialogue1 == other.dialogue1 && dialogue2 == other.dialogue2 && dialogueProgress == other.dialogueProgress;
        }

        public override bool Equals(object obj)
        {
            return obj is Character other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, description, weapon, dialogue1, dialogue2, dialogueProgress);
        }
    }

    public static Character Green = new Character(
     "Green",
     "Wears a Hat, Tie, and a Full Mask.",
     "Weapon: Knuckledusters",
     "Green wears a Hat and a Tie.",
     "Green wears a Full mask.",
     1);

    public static Character Purple = new Character(
        "Purple",
        "Wears a Half mask, Tie and no Hat.",
        "Weapon: Gun",
        "Purple wears a Half-mask and a Tie.",
        "Purple does not wear a Hat.",
        1);

    public static Character Black = new Character(
        "Black",
        "Wears a Half mask, a Hat, and no Tie.",
        "Weapon: Poison",
        "Black wears a half-mask but doesn’t wear a Tie.",
        "Black wears a Hat.",
        1);

    public static Character Yellow = new Character(
        "Yellow",
        "Wears a Full mask, no Hat, and no Tie.",
        "Weapon: Dagger",
        "Yellow doesn’t wear a Tie or a Hat.",
        "Yellow wears a Full mask.",
        1);


    public Character GetCharacterDetails(WhoCharacter who)
    {
        Character details = default;

        switch (who)
        {
            case WhoCharacter.Green:
                details = Green;
                break;
            case WhoCharacter.Purple:
                details = Purple;
                break;
            case WhoCharacter.Black:
                details = Black;
                break;
            case WhoCharacter.Yellow:
                details = Yellow;
                break;
        }

        return details;
    }
    public string GetDialogue(WhoCharacter who)
    {
        string dialogue = "DEFAULT DIALOGUE TEXT";
        
        switch (who.ToString())
        {
            case "Green":
                switch (Green.dialogueProgress)
                {
                    case 1:
                        dialogue = Green.dialogue1;
                        Green.dialogueProgress++;
                        break;
                    case 2:
                        dialogue = Green.dialogue2;
                        Green.dialogueProgress++;
                        break;
                }
                break;
            case "Purple":
                switch (Purple.dialogueProgress)
                {
                    case 1:
                        dialogue = Purple.dialogue1;
                        Purple.dialogueProgress++;
                        break;
                    case 2:
                        dialogue = Purple.dialogue2;
                        Purple.dialogueProgress++;
                        break;
                }
                break;
            case "Black":
                switch (Black.dialogueProgress)
                {
                    case 1:
                        dialogue = Black.dialogue1;
                        Black.dialogueProgress++;
                        break;
                    case 2:
                        dialogue = Black.dialogue2;
                        Black.dialogueProgress++;
                        break;
                }
                break;
            case "Yellow":

                switch (Yellow.dialogueProgress)
                {
                    case 1:
                        dialogue = Yellow.dialogue1;
                        Yellow.dialogueProgress++;
                        break;
                    case 2:
                        dialogue = Yellow.dialogue2;
                        Yellow.dialogueProgress++;
                        break;
                }
                break;
        }
        return dialogue;
    }

    Dictionary<int, string> dict = new Dictionary<int, string>{
        { 0, "Green" },
        { 1, "Purple" },
        { 2, "Black"},
        { 3, "Yellow"} };

    public void OnSubmit()
    {
        string submittedName = dict[dropdown.value];
        if (submittedName == characterDetails.name) return;

        switch (submittedName)
        {
            case "Green":
                switch (Green.dialogueProgress)
                {
                    case 1:
                        dialogueBox.text = Green.dialogue1;
                        Green.dialogueProgress++;
                        break;
                    case 2:
                        dialogueBox.text = Green.dialogue2;
                        Green.dialogueProgress++;
                        break;
                }
                break;
            case "Purple":
                switch (Purple.dialogueProgress)
                {
                    case 1:
                        dialogueBox.text = Purple.dialogue1;
                        Purple.dialogueProgress++;
                        break;
                    case 2:
                        dialogueBox.text = Purple.dialogue2;
                        Purple.dialogueProgress++;
                        break;
                }
                break;
            case "Black":
                switch (Black.dialogueProgress)
                {
                    case 1:
                        dialogueBox.text = Black.dialogue1;
                        Black.dialogueProgress++;
                        break;
                    case 2:
                        dialogueBox.text = Black.dialogue2;
                        Black.dialogueProgress++;
                        break;
                }
                break;
            case "Yellow":
                switch (Yellow.dialogueProgress)
                {
                    case 1:
                        dialogueBox.text = Yellow.dialogue1;
                        Yellow.dialogueProgress++;
                        break;
                    case 2:
                        dialogueBox.text = Yellow.dialogue2;
                        Yellow.dialogueProgress++;
                        break;
                }
                break;
        }

        Destroy(dropdown);

        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);
    }
}
