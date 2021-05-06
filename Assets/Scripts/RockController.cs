using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    float speed = 5f;
    PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -5f)
        {
            playerScript.LoseHealth(1);
            Destroy(gameObject);
        }
    }
}
