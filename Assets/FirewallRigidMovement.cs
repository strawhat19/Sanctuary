using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallRigidMovement : MonoBehaviour
{



public float speedWall = 10.0f;
public Rigidbody rb;
public Vector2 movement;


void Start() {
rb = this.GetComponent<Rigidbody>();

}

void Update() {
    movement = new Vector2();
}


void FixedUpdate() {
    moveWall(movement);
}


void moveWall(Vector2 direction) {
    rb.MovePosition((Vector2)transform.position + (direction * speedWall * Time.deltaTime));
}





}

/* public float speed = 10.0f;
public Rigidbody rb1;
public Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
        rb1 = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    

    }


    void FixedUpdate() {

        moveWall(movement);
     
    }


void moveWall(Vector2 direction) {
rb1.AddForce(direction * speed);
}


}

}*/