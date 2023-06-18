using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomController : MonoBehaviour
{
    public Player player;
    public GameObject bottomPrefab;

    private float startingPostion = 100;
    private GameObject mostRecentBottom;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= startingPostion + 80)
        {
            Destroy(mostRecentBottom);
            mostRecentBottom = Instantiate(bottomPrefab, new Vector3(player.transform.position.x, -105, 0), Quaternion.AngleAxis(0f, new Vector3(0, 0, 1)));
            startingPostion = player.transform.position.x;
        }
    }

    public void Reset()
    {
        startingPostion = 100;
        Destroy(mostRecentBottom);
        mostRecentBottom = Instantiate(bottomPrefab, new Vector3(startingPostion, -105, 0), Quaternion.AngleAxis(0f, new Vector3(0, 0, 1)));
    }
}
