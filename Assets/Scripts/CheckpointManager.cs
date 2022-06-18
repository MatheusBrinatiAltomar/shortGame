using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Player player;
    public GameObject[] checkpointList = new GameObject[10];

    void Start() {
        CheckCheckpointList();
    }

    public void CheckCheckpointList() {
        foreach (var item in checkpointList) {
            if (!item.activeSelf) item.gameObject.SetActive(true);
        }
    }
}
