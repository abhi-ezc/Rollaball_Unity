using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickupPrefab;
    void Start()
    {
        SpawnPickup(10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPickup(int count)
    {
        if (count > 0)
        {
            if (count == 1)
            {
                Instantiate(pickupPrefab);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Instantiate(pickupPrefab);

                }
            }
        }
    }
}
