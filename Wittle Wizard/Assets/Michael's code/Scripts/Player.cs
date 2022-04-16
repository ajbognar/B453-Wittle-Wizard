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
    Vector2 playerVelocity;
    public Spell spellOne;
    public Spell spellTwo;
    public Spell activeSpell;
    public Image spellOneImage;
    public Image spellTwoImage;

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
        // Move();
        //casts spell
        if(Input.GetMouseButtonDown(0)){
            HealthManaManager.instance.SpellCast();
        }

        if(Input.GetKeyDown("q")){
            SwapActive();
        }

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
}

