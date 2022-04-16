using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaManager : MonoBehaviour
{
    public static HealthManaManager instance;
    public float playerHealthCurrent = 30f;
    public float playerHealthMax = 30f;
    public float playerManaCurrent = 20f;
    public float playerManaMax = 20f;
    public int playerGems = 0;
    public Image manaBar;    
    public Image manaBarReal;
    public Image healthBar;
    float manaRegenRate = (float) .007;
    public Animator healthAnimate;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealthCurrent > playerHealthMax){
            playerHealthCurrent = playerHealthMax;
        }
        if(playerManaCurrent > playerManaMax){
            playerManaCurrent = playerManaMax;
        }
        if(playerManaCurrent < 0){
            playerManaCurrent = 0;
        }

        playerManaCurrent += manaRegenRate;
        //adjust the 'real' and 'false' mana bars, also health
        float manaChangePercent = (float) playerManaCurrent / playerManaMax;
        float manaChangePercentFalse = (float) ((playerManaCurrent / playerManaMax) - (Player.instance.activeSpell.cost / playerManaMax));
        float healthChangePercent = (float) playerHealthCurrent / playerHealthMax;
        healthBar.fillAmount = healthChangePercent;

        //triggers health bar animation if health below 50%
        if(healthChangePercent < 0.5f){
            healthAnimate.SetBool("HealthLow", true);
        }
        else{
            healthAnimate.SetBool("HealthLow", false);
        }

        manaBar.fillAmount = manaChangePercentFalse;
        manaBarReal.fillAmount = manaChangePercent;
    }

    public void TakeDamage(float damage)
    {
        CameraShaker.shaker.ShakeScreen(.3f, (damage/10f));
        playerHealthCurrent -= damage;
    }

    public void SpellCast()
    {
        if(playerManaCurrent >= Player.instance.activeSpell.cost){
                manaRegenRate = (float) .007;
                StopAllCoroutines();
                StartCoroutine(StartManaRegen());
                playerManaCurrent -= Player.instance.activeSpell.cost;
                print("Spell " + Player.instance.activeSpell.color + " " + Player.instance.activeSpell.spellName + " was cast!");
            }
    }

    private IEnumerator StartManaRegen() {
        while(true) {
            yield return new WaitForSeconds(3);
            manaRegenRate = (float) .07;
            yield break;
        }
    }
}
