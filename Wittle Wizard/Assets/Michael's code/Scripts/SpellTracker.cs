using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//singleton that helps spells determine what they are
public class SpellTracker : MonoBehaviour
{
    public static SpellTracker spellInstance;
    public Spell trackedSpell;

    void Awake()
    {
        spellInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTrackedSpell(Spell newSpell){
        trackedSpell = newSpell;
    }

    public Spell GetTrackedSpell()
    {
        return trackedSpell;
    }
}
