using System.Collections;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // considering floor as square
    public float floorBounds = 10;
    void Start()
    {
        MoveToRandomPosition();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // if (collision.tag == "Player")
        // {
        //     Destroy(this.gameObject);
        // }
    }

    void OnDisable()
    {
        MoveToRandomPosition();
    }

    void MoveToRandomPosition()
    {
        float randomX = Random.Range(floorBounds * -1, floorBounds);
        float randomZ = Random.Range(floorBounds * -1, floorBounds);
        transform.position = new Vector3(randomX, transform.position.y, randomZ);
    }

    void FixedUpdate()
    {

        transform.Rotate(new Vector3(15, 30, 45) * 3 * Time.deltaTime);
    }
}
