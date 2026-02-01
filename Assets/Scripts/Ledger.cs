using System;
using TMPro;
using UnityEngine;

public class Ledger : MonoBehaviour
{
    public GameObject FullLedger;
    public GameObject Cover;
    public GameObject Accuse;
    public GameObject Facts;
    public GameObject Who;
    public GameObject When;
    public GameObject Where;

    public TMP_Dropdown whoGuess;
    public TMP_Dropdown whereGuess;
    public TMP_Dropdown whenGuess;
    
    // Index in the options
    public int correctWhoGuess;
    public int correctWhereGuess;
    public int correctWhenGuess;

    public void GiveInfo(BoardItem.Clue clue)
    {
        switch (clue.type)
        {
            case BoardItem.Type.Fact:
                break;
            case BoardItem.Type.Who:
                break;
            case BoardItem.Type.When:
                break;
            case BoardItem.Type.Where:
                break;
        }
    }

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
    
    public static Character Green = new Character (
        "Green",
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        1);
    
    public static Character Purple = new Character (
        "Purple",
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        1);
    
    public static Character Black = new Character (
        "Black",
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        1);
    
    public static Character Yellow = new Character (
        "Yellow",
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        1);

    public void Accusation()
    {
        if ((whoGuess.value == correctWhoGuess)
            && (whereGuess.value == correctWhereGuess)
            && (whenGuess.value == correctWhenGuess))
        {
            CorrectAccusation();
        }
        else
        {
            FalseAccusation();
        }
    }
    public void CorrectAccusation()
    {
        Debug.Log("Correct");
    }
    public void FalseAccusation()
    {
        Debug.Log("Incorrect");
    }
    
    public void ToggleLedgerESC()
    {
        GoToCover();
        if (FullLedger.activeSelf)
        {
            CloseLedger();
        }
        else
        {
            OpenLedger();
        }
    }
    public void ToggleLedgerTAB()
    {
        GoToAccuse();
        if (FullLedger.activeSelf)
        {
            CloseLedger();
        }
        else
        {
            OpenLedger();
        }
    }
    public void OpenLedger()
    {
        FullLedger.SetActive(true);

        AkUnitySoundEngine.PostEvent("Book_Open", gameObject);
    }
    public void CloseLedger()
    {
        FullLedger.SetActive(false);


        AkUnitySoundEngine.PostEvent("Book_Close", gameObject);
    }

    public void GoToCover()
    {
        Cover.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);


        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToAccuse()
    {
        Accuse.SetActive(true);
        
        Cover.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToFacts()
    {
        Facts.SetActive(true);
        
        Accuse.SetActive(false);
        Cover.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWho()
    {
        Who.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Cover.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWhen()
    {
        When.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        Cover.SetActive(false);
        Where.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWhere()
    {
        Where.SetActive(true);
    
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Cover.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
