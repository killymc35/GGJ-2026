using System;
using UnityEngine;

public class ClueCreator : MonoBehaviour
{
    public enum Type
    {
        Fact,
        Who,
        Where,
        When
    }
    
    
    [Header("Clue Type")]
    public Type type =  Type.Fact;
    
    [Header("Clue Prefabs")]
    public GameObject factPrefab;
    public GameObject whoPrefab;
    public GameObject wherePrefab;
    public GameObject whenPrefab;

    private void OnValidate()
    {
        switch (type)
        {
            case Type.Fact:
                CreateChildIfNew(factPrefab);
                break;
            case Type.Who:
                CreateChildIfNew(whoPrefab);
                break;
            case Type.Where:
                CreateChildIfNew(wherePrefab);
                break;
            case Type.When:
                CreateChildIfNew(whenPrefab);
                break;
        }
    }

    private void CreateChildIfNew(GameObject child)
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).gameObject.name == child.name) return;
        }
        
        PurgeChildren();
        var creation = Instantiate(child, gameObject.transform);
        if (creation.transform.parent == null) UnityEditor.EditorApplication.delayCall+=() => DestroyImmediate(creation.gameObject, true);
        creation.name = child.name;
    }
    
    private void PurgeChildren()
    {
        foreach (Transform child in transform)
        {
            UnityEditor.EditorApplication.delayCall+=() => DestroyImmediate(child.gameObject, true);
        }
    }
}
