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
    }
    public void CloseLedger()
    {
        FullLedger.SetActive(false);
    }

    public void GoToCover()
    {
        Cover.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);
    }
    public void GoToAccuse()
    {
        Accuse.SetActive(true);
        
        Cover.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);
    }
    public void GoToFacts()
    {
        Facts.SetActive(true);
        
        Accuse.SetActive(false);
        Cover.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);
    }
    public void GoToWho()
    {
        Who.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Cover.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);
    }
    public void GoToWhen()
    {
        When.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        Cover.SetActive(false);
        Where.SetActive(false);
    }
    public void GoToWhere()
    {
        Where.SetActive(true);
    
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Cover.SetActive(false);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
