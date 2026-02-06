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
    public GameObject FactsPage;
    public GameObject WhoPage;
    public GameObject WhenPage;
    public GameObject WherePage;
    public GameObject RulesPage;

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
        timeManagerObject = GameObject.Find("UI Canvas (+ Time Manager)");
    }

    public void GiveInfo(Clue clue)
    {
        switch (clue)
        {
            case Fact:
                LogFact(clue as Fact);
                break;
            case Who:
                LogWho(clue as Who);
                break;
            case When:
                LogWhen(clue as When);
                break;
            case Where:
                LogWhere(clue as Where);
                break;
        }
    }

    public void LogFact(Fact fact)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        facts[factCounter].text = "•  " + fact.fact;
        factCounter++;
    }
    public void LogWho(Who who)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (who.character.ToString())
        {
            case "Green": 
                greenDescription.text = Who.Green.description;
                greenWeapon.text = Who.Green.weapon;
                greenPortrait.SetActive(true);
                break;
            case "Purple": 
                purpleDescription.text = Who.Purple.description;
                purpleWeapon.text = Who.Purple.weapon;
                purplePortrait.SetActive(true);
                break;
            case "Black": 
                blackDescription.text = Who.Black.description;
                blackWeapon.text = Who.Black.weapon;
                blackPortrait.SetActive(true);
                break;
            case "Yellow": 
                yellowDescription.text = Who.Yellow.description;
                yellowWeapon.text = Who.Yellow.weapon;
                yellowPortrait.SetActive(true);
                break; 
        }
    }
    public void LogWhere(Where where)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (where.place)
        {
            case WhereLocation.Ballroom:
                ballroomDescription.text = where.info;
                break;
            case  WhereLocation.Courtyard:
                courtyardDescription.text = where.info;
                break;
            case WhereLocation.Bedchambers:
                bedchambersDescription.text = where.info;
                break;
            case WhereLocation.Study:
                studyDescription.text  = where.info;
                break;
        }
    }
    public void LogWhen(When when)
    {
        AkUnitySoundEngine.PostEvent("Book_Pencil", gameObject);

        switch (when.time)
        {
            case WhenTime.Afternoon:
                afternoonDescription.text = when.info;
                break;
            case  WhenTime.Evening:
                eveningDescription.text = when.info;
                break;
            case WhenTime.Night:
                nightDescription.text = when.info;
                break;
            case WhenTime.Morning:
                morningDescription.text = when.info;
                break;
        }
    }

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
        FactsPage.SetActive(false);
        WhoPage.SetActive(false);
        WhenPage.SetActive(false);
        WherePage.SetActive(false);
        RulesPage.SetActive(false);


        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToAccuse()
    {
        Accuse.SetActive(true);
        
        Cover.SetActive(false);
        FactsPage.SetActive(false);
        WhoPage.SetActive(false);
        WhenPage.SetActive(false);
        WherePage.SetActive(false);
        RulesPage.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToFacts()
    {
        FactsPage.SetActive(true);
        
        Accuse.SetActive(false);
        Cover.SetActive(false);
        WhoPage.SetActive(false);
        WhenPage.SetActive(false);
        WherePage.SetActive(false);
        RulesPage.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWho()
    {
        WhoPage.SetActive(true);
        
        Accuse.SetActive(false);
        FactsPage.SetActive(false);
        Cover.SetActive(false);
        WhenPage.SetActive(false);
        WherePage.SetActive(false);
        RulesPage.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWhen()
    {
        WhenPage.SetActive(true);
        
        Accuse.SetActive(false);
        FactsPage.SetActive(false);
        WhoPage.SetActive(false);
        Cover.SetActive(false);
        WherePage.SetActive(false);
        RulesPage.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToWhere()
    {
        WherePage.SetActive(true);
    
        Accuse.SetActive(false);
        FactsPage.SetActive(false);
        WhoPage.SetActive(false);
        WhenPage.SetActive(false);
        Cover.SetActive(false);
        RulesPage.SetActive(false);

        AkUnitySoundEngine.PostEvent("Book_Page", gameObject);
    }
    public void GoToRules()
    {
        RulesPage.SetActive(true);

        Accuse.SetActive(false);
        Cover.SetActive(false);
        FactsPage.SetActive(false);
        WhoPage.SetActive(false);
        WhenPage.SetActive(false);
        WherePage.SetActive(false);

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
