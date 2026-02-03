using System;
using Unity.Cinemachine;
using UnityEngine;

public abstract class Clue : MonoBehaviour, InteractableObject
{
    public enum State
    {
        Hidden,
        Investigable,
        Revealed
    }
    [Header("State")]
    public State state = State.Hidden;

    public GameObject hidden;
    public GameObject investigable;

    protected string RevealedSoundEffectName = string.Empty;
    
    private void Awake()
    {
        ChangeState(state);
    }

    public void Interact()
    {
        switch (state)
        {
            case State.Hidden:
                break;
            case State.Investigable:
                // TimeManager.Instance.ShowInvestigatePopup(this);
                break;
            case State.Revealed:
                if (SelectionManager.IsSelected(this)) return;
                if (RevealedSoundEffectName != string.Empty) AkUnitySoundEngine.PostEvent(RevealedSoundEffectName, gameObject);
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
                hidden.SetActive(true);
                investigable.SetActive(false);
                break;
            case State.Investigable:
                hidden.SetActive(false);
                investigable.SetActive(true);
                break;
            case State.Revealed:
                hidden.SetActive(false);
                investigable.SetActive(false);
                break;
        }
    }
    
    public abstract void LogInfo();
}
