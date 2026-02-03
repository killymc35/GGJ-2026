using System;
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
    
    [Header("Character Portraits")] 
    public Texture green;
    public Texture purple;
    public Texture black;
    public Texture yelllow;

    private void OnValidate()
    {
        characterDetails = GetCharacter(character);

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
            case "Yelllow":
                characterPortrait.texture = yelllow;
                break;
        }
    }

    public override void LogInfo()
    {
        throw new System.NotImplementedException();
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
        public string dialogue3;
        public int dialogueProgress;

        public Character(string name, string description, string weapon, string dialogue1, string dialogue2, string dialogue3, int dialogueProgress)
        {
            this.name = name;
            this.description = description;
            this.weapon = weapon;
            this.dialogue1 = dialogue1;
            this.dialogue2 = dialogue2;
            this.dialogue3 = dialogue3;
            this.dialogueProgress = dialogueProgress;
        }

        public bool Equals(Character other)
        {
            return name == other.name && description == other.description && weapon == other.weapon && dialogue1 == other.dialogue1 && dialogue2 == other.dialogue2 && dialogue3 == other.dialogue3 && dialogueProgress == other.dialogueProgress;
        }

        public override bool Equals(object obj)
        {
            return obj is Character other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, description, weapon, dialogue1, dialogue2, dialogue3, dialogueProgress);
        }
    }

    public static Character Green = new Character(
     "Green",
     "Wears a Hat, Tie, and a Full Mask.",
     "Weapon: Knuckledusters",
     "Green wears a Hat and a Tie.",
     "Green wears a Full mask.",
     string.Empty,
     1);

    public static Character Purple = new Character(
        "Purple",
        "Wears a Half mask, Tie and no Hat.",
        "Weapon: Gun",
        "Purple wears a Half-mask and a Tie.",
        "Purple does not wear a Hat.",
        string.Empty,
        1);

    public static Character Black = new Character(
        "Black",
        "Wears a Half mask, a Hat, and no Tie.",
        "Weapon: Poison",
        "Black wears a half-mask but doesn’t wear a Tie.",
        "Black wears a Hat.",
        string.Empty,
        1);

    public static Character Yellow = new Character(
        "Yellow",
        "Wears a Full mask, no Hat, and no Tie.",
        "Weapon: Dagger",
        "Yellow doesn’t wear a Tie or a Hat.",
        "Yellow wears a Full mask.",
        string.Empty,
        1);


    public Character GetCharacter(WhoCharacter who)
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
}
