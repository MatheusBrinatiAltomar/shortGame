using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //update the position
        transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }
}
