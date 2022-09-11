using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Player player;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            player.CheckpointReached();
            this.gameObject.SetActive(false);
        }
    }
}
