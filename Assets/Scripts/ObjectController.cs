using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public Player player;
    public float objectCounter = 0f;

    float distance;

    public void Instantiate(Vector3 position, int number) {
        if (objectCounter >= 3f)
            return;
        
        objectCounter += 1f;
        distance = player.moveSpeed + 2f;
        switch (number)
        {
            case 1:
                GameObject newObjectGoingUp = Instantiate(objectToInstantiate, position + new Vector3(distance, 0.5f, 0), Quaternion.AngleAxis(30f, new Vector3(0, 0, 1)));
                Destroy (newObjectGoingUp, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
            case 2:
                GameObject newObjectStraight = Instantiate(objectToInstantiate, position + new Vector3(distance, -1.2f, 0), Quaternion.AngleAxis(0f, new Vector3(0, 0, 1)));
                Destroy(newObjectStraight, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
            case 3:
                GameObject newObjectGoingDown = Instantiate(objectToInstantiate, position + new Vector3(distance, -3f, 0), Quaternion.AngleAxis(-30f, new Vector3(0, 0, 1)));
                Destroy(newObjectGoingDown, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
        }   
    }

    private IEnumerator DestroyCoroutine() {
        yield return new WaitForSeconds (3);
        objectCounter = objectCounter >= 0 && objectCounter <= 3 ? objectCounter - 1f : objectCounter;
    }
}
