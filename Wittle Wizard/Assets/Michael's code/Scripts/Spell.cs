using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "New Spell")]

public class Spell : ScriptableObject
{
    public float cost;
    public string spellName;
    public string color;
    public Sprite icon;
}
