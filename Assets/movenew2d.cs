using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movenew2d : MonoBehaviour
{

    public float acceleration = 5f;
    public float jumpForce = 15f;
    // private float maxSpeed = 10;
    public bool isGrounded = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // float speed_x = movement.x;
        transform.position += movement * Time.deltaTime * acceleration;
        // Vector2 clampedVelocity = speed_x.velocity;
        // clampedVelocity.x = Mathf.Clamp(speed_x.velocity.x, -maxSpeed, maxSpeed);
        // speed_x.velocity = clampedVelocity;
    }



    void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
}
