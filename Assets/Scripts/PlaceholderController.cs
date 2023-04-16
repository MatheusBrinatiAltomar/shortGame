using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderController : MonoBehaviour
{
    public Player player;
    float distance;
    public int type;

    void Update()
    {
        distance = player.moveSpeed + 2f;
        switch (type)
        {
            case 1:
                this.transform.position = (player.transform.position + new Vector3(distance, 2f, 0));
                break;
            case 2:
                this.transform.position = (player.transform.position + new Vector3(distance, -1.5f, 0));
                break;
            case 3:
                this.transform.position = (player.transform.position + new Vector3(distance, -5f, 0));
                break;
        }
    }
}
