using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public GameObject rockPrefab, powerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnElements());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnElements()
    {
        int randomChance;
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            randomChance = Random.Range(1, 16);
            if (randomChance > 1)
            {
                Instantiate(rockPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
            else
            {
                Instantiate(powerPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
        }
    }
}
