using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static InteractableObject SelectedItem;

    public static void Select(InteractableObject item)
    {
        item.OnSelect();
        SelectedItem?.OnDeselect();
        SelectedItem = item;
    }

    public static void ClearSelection()
    {
        SelectedItem?.OnDeselect();
        SelectedItem = null;
    }
}