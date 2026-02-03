using System;
using UnityEngine;

public class StringManager : MonoBehaviour
{
    [Serializable]
    public struct Connection
    {
        public ClueCreator first;
        public ClueCreator second;
    }

    public float stringWidth;
    public Color stringColor;
    public Material stringMaterial;

    public Connection[] Connections;
    
    public static StringManager Instance;

    private void Awake()
    {
        Instance = this;
        
        foreach (Connection connection in Connections)
        {
            var clue1 = connection.first.GetComponentInChildren<Clue>();
            var clue2 = connection.second.GetComponentInChildren<Clue>();
            
            clue1.neighbours.Add(clue2);
            clue2.neighbours.Add(clue1);
            
            var pin1 = clue1.pin;
            var pin2  = clue2.pin;
            
            GameObject newString = new GameObject("String");
            newString.transform.SetParent(transform);
            
            var newScript = newString.AddComponent<String>();
            newScript.firstPin = pin1;
            newScript.secondPin = pin2;

            var stringRenderer = newString.GetComponent<LineRenderer>();
            stringRenderer.widthMultiplier = stringWidth;
            
            Gradient newGradient = new Gradient();
            
            GradientColorKey[] newColorKeys = new GradientColorKey[2];
            newColorKeys[0] = new GradientColorKey(stringColor, 0f);
            newColorKeys[1] = new GradientColorKey(stringColor, 1f);
            
            newGradient.colorKeys = newColorKeys;
            
            stringRenderer.colorGradient = newGradient;
            stringRenderer.material = stringMaterial;
        }
    }
}
