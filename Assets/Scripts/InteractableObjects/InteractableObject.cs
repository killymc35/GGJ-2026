using UnityEngine;

/// <summary>
/// Interactable objects must have colliders
/// </summary>
public interface InteractableObject
{
    public void Interact();
    public void OnSelect();
    public void OnDeselect();
}
