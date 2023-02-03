using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject checkpoint;
    public Player player;
    float timer;
    float interval = 2f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (player.transform.position + new Vector3(player.moveSpeed + 20f, 0f, 0));
        timer += Time.deltaTime;
        if (timer >+ interval)
        {
            SpawnObstacle();
            timer -= interval;
        }
    }

    private void SpawnObstacle() {
        if (Random.Range(1, 6) == 5) {
            Instantiate(checkpoint, this.transform.position + new Vector3(0f, Random.Range(-5.0f, 10.0f), 0f), Quaternion.AngleAxis(Random.Range(-40.0f, 40.0f), new Vector3(0, 0, 1)));
        } else {
            Instantiate(obstacle, this.transform.position + new Vector3(0f, Random.Range(-5.0f, 10.0f), 0f), Quaternion.AngleAxis(Random.Range(-40.0f, 40.0f), new Vector3(0, 0, 1)));
        }
    }
}
