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
        int rockCount = 0;
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (rockCount < 15)
            {
                Instantiate(rockPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
                rockCount++;
            }
            else
            {
                Instantiate(powerPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
                rockCount = 0;
            }
        }
    }
}
