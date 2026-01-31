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

    public GameObject[] images;
    
    public GameObject[] neighbours;
    
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

        var stateNumber = (int)currentState;
        images[stateNumber].SetActive(true);
        for (var i = 0; i < stateNumber; i++)
        {
            images[i].SetActive(false);
        }
    }

    public void Interact()
    {
        switch (currentState)
        {
            case State.Hidden:
                break;
            case State.Investigable:
                currentState = State.Revealed;
                SelectionManager.Select(this);
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.GetComponent<BoardItem>().currentState == State.Hidden)
                    {
                        neighbour.GetComponent<BoardItem>().currentState = State.Investigable;
                    }
                }
                break;
            case State.Revealed:
                SelectionManager.Select(this);
                break;
        }
        
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
