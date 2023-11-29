using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool facingRight = true;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if ((moveInput > 0 && !facingRight) || (moveInput < 0 && facingRight)){
            FlipCharacter();
        }

        if (Input.GetButtonDown("Jump") && isGrounded){
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    void FlipCharacter() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
        }
    }
}
