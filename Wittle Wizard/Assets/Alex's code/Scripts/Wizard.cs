using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] float _jumpSpeed = 5;
    [SerializeField] Transform GroundPos;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float jumpTimer = 0f;
    // Start is called before the first frame update
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
        Move();
        Jump();
    }

    void Move() {
        float dir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(dir * 6, rb.velocity.y, 0);
        if (dir < 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dir > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, _jumpSpeed, 0);
            // isGrounded = false;
        }

        if (!isGrounded) {
            jumpTimer += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(GroundPos.position, .05f);
    }
}
