using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{
    public enum State
    {
        Hidden,
        Investigable,
        Revealed
    }
    public State currentState = State.Hidden;
    public bool beginsInvestigable = true;
    
    public InteractableObject[] neighbours;
    
    private MeshCollider meshCollider;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();   
        
        if (beginsInvestigable)
        {
            currentState = State.Investigable;
            SelectionManager.MakeSelectable(this);
        }
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Hidden:
                meshCollider.enabled = false;
                break;
            case State.Investigable:
            {
                meshCollider.enabled = true;
                break;
            }
            case State.Revealed:
            {
                meshCollider.enabled = true;
                break;
            }
        }
        
        
        else {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void Interact()
    {
        SelectionManager.Select(this);
    }

    public void OnSelect()
    {
        gameObject.GetComponentInChildren<CinemachineCamera>().Priority = 2;
        
        Debug.Log($"Selected {gameObject.name}");
    }

    public void OnDeselect()
    {
        gameObject.GetComponentInChildren<CinemachineCamera>().Priority = 0;
        
        Debug.Log($"Deselected {gameObject.name}");
    }
}
