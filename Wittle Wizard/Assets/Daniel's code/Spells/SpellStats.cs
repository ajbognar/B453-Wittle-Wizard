using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStats : MonoBehaviour
{
    public float damage = 0;
    public float speed = 0;
    public float spellCost = 0;
    public float coolDown = 0;
    [SerializeField] AudioSource sound;
    public float spellColor = 1; //1 - red, 2 - green, 3 - blue
}
