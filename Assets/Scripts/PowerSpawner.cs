using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject powerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowers());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnPowers()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(15f);
            Instantiate(powerPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
