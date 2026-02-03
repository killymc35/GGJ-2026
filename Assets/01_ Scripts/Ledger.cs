using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public int factCounter = 0;
    public TextMeshProUGUI[] facts;
    
    public TextMeshProUGUI greenDescription;
    public TextMeshProUGUI greenWeapon;
    public GameObject greenPortrait;
    
    public TextMeshProUGUI purpleDescription;
    public TextMeshProUGUI purpleWeapon;
    public GameObject purplePortrait;
    
    public TextMeshProUGUI blackDescription;
    public TextMeshProUGUI blackWeapon;
    public GameObject blackPortrait;
    
    public TextMeshProUGUI yellowDescription;
    public TextMeshProUGUI yellowWeapon;
    public GameObject yellowPortrait;
    
    public TextMeshProUGUI ballroomDescription;
    public TextMeshProUGUI courtyardDescription;
    public TextMeshProUGUI bedchambersDescription;
    public TextMeshProUGUI studyDescription;
    
    public TextMeshProUGUI afternoonDescription;
    public TextMeshProUGUI eveningDescription;
    public TextMeshProUGUI nightDescription;
    public TextMeshProUGUI morningDescription;
    
    public float showFalseAccuseTime = 1.5f;
    public GameObject falseAccuse;

    public int accuseAttempts = 0;
    public int maxAccuseAttempts = 1;

    private GameObject timeManagerObject;

    public static Ledger Instance;

    private void Start()
    {
        Instance = this;
        timeManagerObject = GameObject.Find("TimeManager");
    }

    /*public void GiveInfo(BoardItem.Clue clue)
    {
        switch (clue.type)
        {
            case BoardItem.Type.Fact:
                LogFact(clue.description);
                break;
            case BoardItem.Type.Who:
                LogWho(clue.whoCharacter);
                break;
            case BoardItem.Type.When:
                LogWhen(clue.whenTime, clue.description);
                break;
            case BoardItem.Type.Where:
                LogWhere(clue.whereLocation, clue.description);
                break;
        }
    }*/

    /*public string GetDialogue(string name)
    {
        string dialogue = "DEFAULT DIALOGUE TEXT";
        switch (name)
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
    }*/

    public void LogFact(string fact)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        facts[factCounter].text = "•  " + fact;
        factCounter++;
    }
    public void LogWho(string who)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (who)
        {
            /*case "Green": 
                greenDescription.text = Green.description;
                greenWeapon.text = Green.weapon;
                greenPortrait.SetActive(true);
                break;
            case "Purple": 
                purpleDescription.text = Purple.description;
                purpleWeapon.text = Purple.weapon;
                purplePortrait.SetActive(true);
                break;
            case "Black": 
                blackDescription.text = Black.description;
                blackWeapon.text = Black.weapon;
                blackPortrait.SetActive(true);
                break;
            case "Yellow": 
                yellowDescription.text = Yellow.description;
                yellowWeapon.text = Yellow.weapon;
                yellowPortrait.SetActive(true);
                break; */
        }
    }
    /*public void LogWhere(WhereLocation location, string info)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (location)
        {
            case WhereLocation.Ballroom:
                ballroomDescription.text =  info;
                break;
            case  WhereLocation.Courtyard:
                courtyardDescription.text = info;
                break;
            case WhereLocation.Bedchambers:
                bedchambersDescription.text = info;
                break;
            case WhereLocation.Study:
                studyDescription.text  = info;
                break;
        }
    }
    public void LogWhen(WhenTime time, string info)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (time)
        {
            case WhenTime.Afternoon:
                afternoonDescription.text = info;
                break;
            case  WhenTime.Evening:
                eveningDescription.text = info;
                break;
            case WhenTime.Night:
                nightDescription.text = info;
                break;
            case WhenTime.Morning:
                morningDescription.text = info;
                break;
        }
    }*/

    public enum WhereLocation
    {
        Ballroom,
        Courtyard,
        Bedchambers,
        Study
    }
    public enum WhenTime
    {
        Afternoon,
        Evening,
        Night,
        Morning
    }
    

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
        AkUnitySoundEngine.PostEvent("Accuse_Success", timeManagerObject);
        
        SceneManager.LoadScene(3);
        Debug.Log("Correct");
    }
    public void FalseAccusation()
    {
        if (accuseAttempts >= maxAccuseAttempts)
        {
            AkUnitySoundEngine.PostEvent("Accuse_Fail_Game_Over", timeManagerObject);

            SceneManager.LoadScene(2);
        }
        else
        {
            accuseAttempts++;
            StartCoroutine(ShowFalseAccusation());
            Debug.Log("Incorrect");

            AkUnitySoundEngine.PostEvent("Accuse_Fail_Continue", timeManagerObject);
        }
    }
    
    public IEnumerator ShowFalseAccusation()
    {
        var showingFor = 0f;
        falseAccuse.SetActive(true);
        while (showingFor < showFalseAccuseTime)
        {
            showingFor += Time.deltaTime;
            yield return null;
        }
        falseAccuse.SetActive(false);
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
    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToBoard()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLoss()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToWin()
    {
        SceneManager.LoadScene(3);
    }
}
