using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{
    public void Interact()
    {
        gameObject.GetComponentInChildren<CinemachineCamera>().Priority = 2;
        
        Debug.Log("Interaction Registered");
    }
}
