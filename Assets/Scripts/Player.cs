using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f;
    public float jumpForce = 10f;
    public float fallMultiplier = 10f;

    private Rigidbody2D rb;
    private float hInput;
    private bool jumpInput = false;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && rb.velocity.y < 0.001)
        {
            jumpInput = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(hInput * speed * Time.deltaTime, rb.velocity.y);
        if (jumpInput && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpInput = false;
            isGrounded = false;
        }
        if (rb.velocity.y < 0)
        {
            float newVel = rb.velocity.y + (-9.81f * fallMultiplier * Time.fixedDeltaTime);
            rb.velocity = new Vector2(rb.velocity.x, newVel);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" && isGrounded == false) {
            isGrounded = true;
        }
    }
}
