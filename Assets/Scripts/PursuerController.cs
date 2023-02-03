using UnityEngine;

public class PursuerController : MonoBehaviour
{
    public Player player;
    public Vector3 velocity;
    Vector3 startingPosition = new Vector3(0,0,0);
    Vector3 checkpointPosition = new Vector3(0,0,0);

    void Start() {
        startingPosition = this.transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, player.moveSpeed * Time.deltaTime);
    }

    public void ResetPosition() {
        this.transform.position = checkpointPosition != Vector3.zero ? checkpointPosition : startingPosition;
    }

    public void CheckpointReached() {
        checkpointPosition = player.transform.position + new Vector3(-10f, 0, 0);
    }

    public void DeathReset() {
        checkpointPosition = startingPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            player.Death();
        }
    }
}
