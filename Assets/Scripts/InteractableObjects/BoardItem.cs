using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{
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
