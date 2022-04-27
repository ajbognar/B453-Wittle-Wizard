using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New ItemDropTracker")]
public class ItemDropTracker : ScriptableObject
{
    public bool initialized = false;
    public int gemTracker;
    public int healthTracker;
    public int manaTracker;
}