using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{
    public bool beginsSelectable = false;
    public InteractableObject[] neighbours;

    private void Start()
    {
        if (beginsSelectable)
        {
            SelectionManager.MakeSelectable(this);
        }
    }

    private void Update()
    {
        if (!SelectionManager.IsSelectable(this))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
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
