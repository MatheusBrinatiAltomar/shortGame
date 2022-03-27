using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
    float jumpHeight = 4;

    float timeToJumpApex = .4f;

    float moveSpeed = 6;

    float gravity = -2;

    float velocityXSmoothing;

    float jumpVelocity = 8;

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    public int health = 3;

    Vector3 startingPosition = new Vector3(0,0,0);

    public Vector3 velocity;

    Controller2D controller;
    
    void Start() {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight)/Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        startingPosition = this.transform.position;
    }

    void Update() {

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded :accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (this.transform.position.y < -100f) {
            Death();
        }
    }

    void Death() {
        health -= 1;
        if (health == 0) {
            Debug.Log("Game Over!");
        }
        this.transform.position = startingPosition;
    }
}
