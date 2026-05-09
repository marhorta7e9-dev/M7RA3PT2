using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class PlayerScriptableObject : ScriptableObject
{
    public string nom;
    public int vida;
    public int atac;
}