using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public GameObject trail;

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            GameObject instance = (GameObject)Instantiate(trail, transform.position, Quaternion.identity);
            Destroy(instance, 0.5f);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
