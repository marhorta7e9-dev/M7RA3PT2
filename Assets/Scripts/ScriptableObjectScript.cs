using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class ScriptableObjectScript : ScriptableObject
{
    public Sprite image;
    public int price;
}