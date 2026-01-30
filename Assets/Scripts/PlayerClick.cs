using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClick : MonoBehaviour
{
    public void Click(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        
        var mousePosition = Mouse.current.position.ReadValue();
        var clickRay = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(clickRay, out var hit))
        {
            if (hit.collider.gameObject.TryGetComponent<InteractableObject>(out var interactableObject))
            {
                interactableObject.Interact();
            }
        }
    }
}
