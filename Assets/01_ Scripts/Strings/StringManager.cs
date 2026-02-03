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

    private void Start()
    {
        foreach (Connection connection in Connections)
        {
            var pin1 = connection.first.GetComponentInChildren<Clue>().pin;
            var pin2 = connection.second.GetComponentInChildren<Clue>().pin;
            
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
