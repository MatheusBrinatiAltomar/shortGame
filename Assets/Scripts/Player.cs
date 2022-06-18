using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
    float jumpHeight = 8;

    float timeToJumpApex = .6f;

    public float moveSpeed = 6;

    float gravity = -2;

    float velocityXSmoothing;

    float jumpVelocity = 8;

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    public int health = 3;

    Vector3 startingPosition = new Vector3(0, 0, 0);
    Vector3 checkpointPosition = new Vector3(0, 0, 0);

    public Vector3 velocity;

    Controller2D controller;
    public PursuerController pursuerController;
    public CheckpointManager checkpointManager;
    
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

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded :accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (this.transform.position.y < -100f) {
            Death();
        }
    }

    public void Death() {
        health -= 1;
        if (health == 0) {
            health = 3;
            DeathReset();
            pursuerController.DeathReset();
        }
        ResetPosition();
        pursuerController.ResetPosition();
    }

    public void DeathReset() {
        moveSpeed = 6;
        checkpointPosition = startingPosition;
        checkpointManager.CheckCheckpointList();
    }

    public void ResetPosition() {
        this.transform.position = checkpointPosition != Vector3.zero ? checkpointPosition : startingPosition;
    }

    public void CheckpointReached() {
        if (health < 3 && health >= 0) health += 1;
        moveSpeed += 1;
        checkpointPosition = this.transform.position;
        pursuerController.CheckpointReached();
    }
}
