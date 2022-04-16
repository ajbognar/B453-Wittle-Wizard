using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 800;
    [SerializeField] Transform GroundPos;
    Rigidbody2D rb;
    bool isGrounded = false;
    private float jumpTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircleAll(GroundPos.position, .05f, LayerMask.GetMask("Ground")).Length > 0 && jumpTimer >= .25f) {
            isGrounded = true;
            jumpTimer = 0;
        }
        Movement();
    }
    void Movement()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            //Move Right
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            //Move Left
            transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
        if (!isGrounded) {
            jumpTimer += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(GroundPos.position, .05f);
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")//ground check
        {
            isGrounded = true;
        }
    }*/

}
