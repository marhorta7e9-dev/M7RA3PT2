using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Objects/NewPlayer")]
public class PlayerScriptableObject : ScriptableObject
{
    public string nom;
    public int vida;
    public int atac;
}