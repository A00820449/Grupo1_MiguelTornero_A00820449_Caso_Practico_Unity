using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public UnityEngine.UI.Text gameovertext;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        gameovertext.gameObject.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().Reset();
        
        GameObject[] objectlist = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject gameobject in objectlist)
        {
            Destroy(gameobject);
        }

        objectlist = GameObject.FindGameObjectsWithTag("Power");
        foreach (GameObject gameobject in objectlist)
        {
            Destroy(gameobject);
        }

        objectlist = GameObject.FindGameObjectsWithTag("Meteorite");
        foreach (GameObject gameobject in objectlist)
        {
            Destroy(gameobject);
        }
    }

    public void SayTest()
    {
        Debug.Log("Test");
    }
}
