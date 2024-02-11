using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public static Character instance;
    public Vector2 acceleration;
    public Vector2 max_speed;
    public float jump_speed;

    bool is_grounded;
    float jumps;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator an;

    void Start() {
        instance = this;
        speed = new Vector2();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    Vector2 speed;
    float try_speed;
    bool jumping;
    int cur_jumps = 1;

    void Update() {
        if (complete) {
            DoAnimation();
            return;
        }
        
        // Where are we trying to move
        try_speed = 0;
        try_speed = Input.GetAxis("Horizontal");
        if (Mathf.Abs(try_speed) < .1f) try_speed = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? 1 : Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;

        // If negative, they are going different direciton
        if (try_speed != 0 && speed.x * try_speed < 0) {
            // Triple the acceleration for better feel
            speed.x += try_speed * acceleration.x * Time.deltaTime;
            speed.x += try_speed * acceleration.x * Time.deltaTime;
            speed.x += try_speed * acceleration.x * Time.deltaTime;
        }
        else if (try_speed != 0) {
            speed.x += try_speed * acceleration.x * Time.deltaTime;
        }

        // Try speed is 0, return to normal
        else {
            speed.x -= speed.x * acceleration.x * Time.deltaTime * .5f;
            if (Mathf.Abs(speed.x) < .05f) {
                speed.x = 0;
            }
        }

        // Limit it to the max
        speed.x = Mathf.Clamp(speed.x, -max_speed.x, max_speed.x);

        if (cur_jumps > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            jumping = true;
        }

        DoAnimation();
    }

    bool complete;
    public void CompleteLevel() {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        complete = true;
        try_speed = 0;
        speed = Vector2.zero;
        DoAnimation();
    }

    public void Die() {
        Manager_Game.instance.Restart();
    }

    Vector2 future_position;
    private void FixedUpdate() {
        // Future_position = transform.position;
        // Future_position.x += (speed.x * Time.deltaTime);
        if (jumping) {
            jumping = false;
            // Only take away jump if in air
            if (!is_grounded)
                cur_jumps--;
            // rb.AddForce(new Vector2(0f, jump_speed), ForceMode2D.Impulse);
            rb.velocity = new Vector2(speed.x, jump_speed);
        } else {
            rb.velocity = new Vector2(speed.x, Mathf.Clamp(rb.velocity.y, -max_speed.y, max_speed.y));
        }
        // rb.MovePosition(future_position);
    }

    void DoAnimation() {
        if (rb.velocity.x > .1f) { // Move Right
            an.SetBool("Running", true);
            sr.flipX = true;
            an.speed = rb.velocity.x / max_speed.x;
        } else if (rb.velocity.x < -.1f) { // Move Left
            an.SetBool("Running", true);
            sr.flipX = false;
            an.speed = -rb.velocity.x / max_speed.x;
        } else { // Idle
            an.SetBool("Running", false);
            an.speed = 1;
        }

        an.SetBool("Grounded", is_grounded);

        an.SetFloat("MoveSpeed_X", rb.velocity.x);
        an.SetFloat("MoveSpeed_Y", rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            is_grounded = true;
            cur_jumps = 1;
        } else if(collision.tag == "Die") {
            Die();
        }
    }

    public void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            is_grounded = true;
            cur_jumps = 1;
        } else if (collision.tag == "Die") {
            Die();
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            is_grounded = false;
        } else if (collision.tag == "Die") {
            Die();
        }
    }
}