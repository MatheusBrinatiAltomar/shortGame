using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public Player player;

    float distance;

    public void Instantiate(Vector3 position, int number) {
        distance = Mathf.Sign(player.velocity.x) == 1 ? 7f : -7f;
        switch (number)
        {
            case 1:
                GameObject newObjectGoingUp = Instantiate(objectToInstantiate, position + new Vector3(distance, 0, 0), Quaternion.AngleAxis(30f, new Vector3(0, 0, 1)));
                Destroy(newObjectGoingUp, 3f);
                break;
            case 2:
                GameObject newObjectStraight = Instantiate(objectToInstantiate, position + new Vector3(distance, 0, 0), Quaternion.AngleAxis(0f, new Vector3(0, 0, 1)));
                Destroy(newObjectStraight, 3f);
                break;
            case 3:
                GameObject newObjectGoingDown = Instantiate(objectToInstantiate, position + new Vector3(distance, 0, 0), Quaternion.AngleAxis(-30f, new Vector3(0, 0, 1)));
                Destroy(newObjectGoingDown, 3f);
                break;
        }
        
    }
}
