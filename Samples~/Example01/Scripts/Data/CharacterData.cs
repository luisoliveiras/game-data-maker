using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;
    public int luckyNumber;
    public SerializableColor color;
}

[System.Serializable]
public struct SerializableColor
{
    public float r;
    public float g;
    public float b;
    public float a;

    public SerializableColor (Color color)
    {
        r = color.r;
        g = color.g;
        b = color.b;
        a = color.a;
    }

    public Color Color
    {
        get
        {
            return new Color(r, g, b, a);
        }
        set
        {
            r = value.r;
            g = value.g;
            b = value.b;
            a = value.a;
        }
    }
}