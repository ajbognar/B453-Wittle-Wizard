using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] float _moveSpeed = 6f;
    [SerializeField] float _moveSpeedUp = 3f;
    public float playerHealthCurrent = 30f;
    public float playerHealthMax = 30f;
    public float playerManaCurrent = 20f;
    public float playerManaMax = 20f;
    public int playerGems = 0;
    public Image manaBar;    
    public Image manaBarReal;
    public Image healthBar;
    Vector2 playerVelocity;
    float manaRegenRate = (float) .007;
    public float spellCost = (float) 5;
    public Spell spellOne;
    public Spell spellTwo;
    public Spell activeSpell;
    public Image spellOneImage;
    public Image spellTwoImage;
    public Animator healthAnimate;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spellOneImage.sprite = spellOne.icon;
        spellTwoImage.sprite = spellTwo.icon;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //undo impossible health and mana values (above max, below 0)
        if(playerHealthCurrent > playerHealthMax){
            playerHealthCurrent = playerHealthMax;
        }
        if(playerManaCurrent > playerManaMax){
            playerManaCurrent = playerManaMax;
        }
        if(playerManaCurrent < 0){
            playerManaCurrent = 0;
        }

        //test for health damage
        if(Input.GetKeyDown("l")){
            TakeDamage(10f);
        }

        if(Input.GetKeyDown("k")){
            TakeDamage(2f);
        }

        if(Input.GetKeyDown("j")){
            TakeDamage(20f);
        }

        //test for mana damage, start regen coroutine
        if(Input.GetMouseButtonDown(0)){
            if(playerManaCurrent >= spellCost){
                manaRegenRate = (float) .007;
                StopAllCoroutines();
                StartCoroutine(StartManaRegen());
                playerManaCurrent -= activeSpell.cost;
                print("Spell " + activeSpell.color + " " + activeSpell.name + " was cast!");
            }
        }

        if(Input.GetKeyDown("q")){
            SwapActive();
        }

        playerManaCurrent += manaRegenRate;
        //adjust the 'real' and 'false' mana bars, also health
        float manaChangePercent = (float) playerManaCurrent / playerManaMax;
        float manaChangePercentFalse = (float) ((playerManaCurrent / playerManaMax) - (spellCost / playerManaMax));
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

    void FixedUpdate()
    {
        isGrounded = false;
    }

    void Move()
    {
        //standard player control, jumping and left/right movement
        playerVelocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
        if(Input.GetButtonDown("Jump") && isGrounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _moveSpeedUp);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    //deals damage to player
    public void TakeDamage(float damage)
    {
        CameraShaker.shaker.ShakeScreen(.3f, (damage/10f));
        playerHealthCurrent -= damage;
    }

    //change the spell in the active slot
    void SwapActive()
    {      
        if(activeSpell.name == spellOne.name){
            activeSpell = spellTwo;
        }
        else{
            activeSpell = spellOne;
        }
        
    }

    //replace current active spell with a new spell
    public void SetActive(Spell newSpell)
    {
        if(activeSpell.name == spellOne.name){
            spellOne = newSpell;
            spellOneImage.sprite = newSpell.icon;
            activeSpell = spellOne;
        }
        else{
            spellTwo = newSpell;
            spellTwoImage.sprite = newSpell.icon;
            activeSpell = spellTwo;
        }
    }

    //wait 3 seconds and then return mana regen to normal value
    private IEnumerator StartManaRegen() {
    while(true) {
        yield return new WaitForSeconds(3);
        manaRegenRate = (float) .07;
        yield break;
    }
}
}

