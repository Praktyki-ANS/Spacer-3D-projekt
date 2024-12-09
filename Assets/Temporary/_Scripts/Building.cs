using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="budynek", menuName = "ScriptableObjects/building")]
public class Building : ScriptableObject
{
    public string Name;
    public TextEditor Address;
}
