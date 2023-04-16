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
                GameObject newObjectGoingUp = Instantiate(objectToInstantiate, position + new Vector3(distance, 2f, 0), Quaternion.AngleAxis(30f, new Vector3(0, 0, 1)));
                Destroy (newObjectGoingUp, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
            case 2:
                GameObject newObjectStraight = Instantiate(objectToInstantiate, position + new Vector3(distance, -1.5f, 0), Quaternion.AngleAxis(0f, new Vector3(0, 0, 1)));
                Destroy(newObjectStraight, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
            case 3:
                GameObject newObjectGoingDown = Instantiate(objectToInstantiate, position + new Vector3(distance, -5f, 0), Quaternion.AngleAxis(-30f, new Vector3(0, 0, 1)));
                Destroy(newObjectGoingDown, 3f);
                StartCoroutine(DestroyCoroutine());
                break;
        }   
    }

    private IEnumerator DestroyCoroutine() {
        yield return new WaitForSeconds (3);
        objectCounter = objectCounter >= 0 && objectCounter <= 3 ? objectCounter - 1f : objectCounter;
    }

    public void DestroyUnecessaryObjects(Vector3 playerPosition) {
        var objectsToBeDestroyed = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int i = 0; i < objectsToBeDestroyed.Length; i++)
        {
            if (objectsToBeDestroyed[i].transform.position.x < playerPosition.x)
            {
                Destroy(objectsToBeDestroyed[i]);
            }
        }
    }

    public void DestroyAllObjects() {
        var objectsToBeDestroyed = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int i = 0; i < objectsToBeDestroyed.Length; i++)
        {
            Destroy(objectsToBeDestroyed[i]);
        }
    }
}
