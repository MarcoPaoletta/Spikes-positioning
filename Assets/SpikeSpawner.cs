using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    float minimumOffset = -5f;
    float maximumOffset = 5f;
    float spikesOffset;
    Vector2 sizeOfPrefab;

    void Start()
    {
        sizeOfPrefab = spikePrefab.transform.localScale;
    }

    void SpawnSpike()
    {
        spikesOffset = Random.Range(minimumOffset, maximumOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, spikesOffset, transform.position.z);

        if(!Physics2D.BoxCast(spawnPosition, sizeOfPrefab, 0, Vector2.down, .1f))
        {
            Instantiate(spikePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Instantiated");
        }
        else
        {
            Debug.Log("No room :(");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSpike();
        }
    }
}
