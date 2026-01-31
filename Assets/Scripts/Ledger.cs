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

    public void ToggleLedger()
    {
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

        ReturnToCover();
    }

    public void ReturnToCover()
    {
        Cover.SetActive(true);
        
        Accuse.SetActive(false);
        Facts.SetActive(false);
        Who.SetActive(false);
        When.SetActive(false);
        Where.SetActive(false);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
