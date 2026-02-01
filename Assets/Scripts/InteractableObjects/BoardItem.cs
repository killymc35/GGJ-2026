using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{

    public Dictionary<int, Ledger.Character> dropdownConversion = new Dictionary<int, Ledger.Character>
    {
        {0, Ledger.Green},
        {1, Ledger.Purple},
        {2, Ledger.Black},
        {3, Ledger.Yellow}
    };
    
    public TMP_Dropdown whoDropdown;
    
    public GameObject ledger;
    
    public enum Type
    {
        Fact,
        Who,
        Where,
        When
    }
    public Type type;

    [Serializable]
    public struct Clue
    {
        public Type type;
        public string description;
        public Ledger.Character whoInterviewee;
        public Ledger.WhereLocation whereLocation;
        public Ledger.WhenTime whenTime;
    }

    public Clue clue;
    
    public enum State
    {
        Hidden,
        Investigable,
        Revealed
    }
    public State currentState = State.Hidden;
    public bool beginsInvestigable = true;
    public TextMeshProUGUI costText;

    public GameObject[] images;
    public GameObject[] neighbours;
    
    private MeshCollider meshCollider;

    public int timeCost = 1;

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
                costText.text = "";
                break;
            case State.Investigable:
            {
                meshCollider.enabled = true;
                switch (timeCost)
                {
                    case 1:
                        costText.text = "1hr";
                        break;
                    case 3:
                        costText.text = "3hrs";
                        break;
                }
                break;
            }
            case State.Revealed:
            {
                costText.text = "";
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
                TimeManager.Instance.ShowInvestigatePopup(this);
                break;
            case State.Revealed:
                SelectionManager.Select(this);
                break;
        }
    }
    
    public void MarkAsRevealed()
    {
        currentState = State.Revealed;
        SelectionManager.MakeSelectable(this);
        SelectionManager.Select(this);
        foreach (var neighbour in neighbours)
        {
            if (neighbour.GetComponent<BoardItem>().currentState == State.Hidden)
            {
                neighbour.GetComponent<BoardItem>().currentState = State.Investigable;
            }
        }

        var ledgerScript = ledger.GetComponent<Ledger>();

        if (clue.type != Type.Who)
        {
            ledgerScript.GiveInfo(clue);
        }
    }

    public void WhoGiveInfo()
    {
        var number = whoDropdown.value;
        var character = dropdownConversion[number];

        if (character.Equals(clue.whoInterviewee)) return;
        
        var ledgerScript = ledger.GetComponent<Ledger>();
        ledgerScript.GiveInfo(clue);

        AkUnitySoundEngine.PostEvent("Investigation_Who", gameObject);

        Destroy(whoDropdown.gameObject);
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
