using System;
using Unity.Cinemachine;
using UnityEngine;
using TMPro;

public abstract class Clue : MonoBehaviour, InteractableObject
{
    public enum State
    {
        Hidden,
        Investigable,
        Revealed
    }

    [Header("String")] public GameObject pin;
    
    [Header("State")]
    public State state = State.Hidden;

    public GameObject hidden;
    public GameObject investigable;

    protected string RevealedSoundEffectName = string.Empty;
    
    [Header("Investigation")]
    public int timeToInvestigate;
    public TextMeshProUGUI costText;
    
    private MeshCollider meshCollider;
    
    private void Awake()
    {
        meshCollider  = GetComponent<MeshCollider>();
        ChangeState(state);
    }

    public void Interact()
    {
        switch (state)
        {
            case State.Hidden:
                break;
            case State.Investigable:
                TimeManager.Instance.ShowInvestigatePopup(this);
                break;
            case State.Revealed:
                if (SelectionManager.IsSelected(this)) return;
                SelectionManager.Select(this);
                break;
        }
    }

    public void OnSelect()
    {
        gameObject.GetComponentInChildren<CinemachineCamera>().Priority = 2;
    }

    public void OnDeselect()
    {
        gameObject.GetComponentInChildren<CinemachineCamera>().Priority = 0;
    }

    public void ChangeState(State newState)
    {
        state = newState;

        switch (state)
        {
            case State.Hidden:
                meshCollider.enabled = false;
                costText.text = string.Empty;
                hidden.SetActive(true);
                investigable.SetActive(false);
                break;
            case State.Investigable:
                meshCollider.enabled = true;

                if (timeToInvestigate == 1) costText.text = timeToInvestigate.ToString() + "hr";
                else  costText.text = timeToInvestigate.ToString() + "hrs";
                
                hidden.SetActive(false);
                investigable.SetActive(true);
                break;
            case State.Revealed:
                meshCollider.enabled = true;
                hidden.SetActive(false);
                investigable.SetActive(false);
                
                if (RevealedSoundEffectName != string.Empty) AkUnitySoundEngine.PostEvent(RevealedSoundEffectName, gameObject);
                
                Ledger.Instance.GiveInfo(this);
                break;
        }
    }
}
