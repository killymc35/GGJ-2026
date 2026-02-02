using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static InteractableObject SelectedItem;
    public static List<InteractableObject> SelectableItems = new List<InteractableObject>();

    public static void Select(InteractableObject item)
    {
        if (!SelectableItems.Contains(item)) return;
        
        item.OnSelect();
        SelectedItem?.OnDeselect();
        SelectedItem = item;
    }

    public static void ClearSelection()
    {
        SelectedItem?.OnDeselect();
        SelectedItem = null;
    }

    public static void MakeSelectable(InteractableObject item)
    {
        SelectableItems.Add(item);
    }

    public static void RemoveSelectable(InteractableObject item)
    {
        SelectableItems.Remove(item);
    }

    public static bool IsSelected(InteractableObject item)
    {
        return SelectedItem == item;
    }
    
    public static bool IsSelectable(InteractableObject item)
    {
        return SelectableItems.Contains(item);
    }
}