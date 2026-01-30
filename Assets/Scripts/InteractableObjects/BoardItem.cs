using System.Collections;
using UnityEngine;

public class BoardItem : MonoBehaviour, InteractableObject
{
    public void Interact()
    {
        Debug.Log("Interaction Registered");
    }
}
