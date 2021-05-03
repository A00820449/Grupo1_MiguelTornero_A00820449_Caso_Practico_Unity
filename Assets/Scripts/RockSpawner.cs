using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRocks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRocks()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            Instantiate(rockPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
