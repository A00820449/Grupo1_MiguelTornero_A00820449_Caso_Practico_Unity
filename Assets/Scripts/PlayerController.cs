using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float xInput;
    public float speed;
    public UnityEngine.UI.Text scoreboard;
    public UnityEngine.UI.Text healthcount;
    public UnityEngine.UI.Text gameovertext;
    public UnityEngine.UI.Button playbutton;
    int score;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreboard.text = score.ToString();
        health = 3;
        healthcount.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        xInput = Mathf.Clamp(xInput, -9f, 9f);
        transform.position = new Vector3(xInput, -3.5f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            score++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Power"))
        {
            StartCoroutine(PowerUp());
            Destroy(other.gameObject);
        }
        scoreboard.text = score.ToString();
    }

    IEnumerator PowerUp()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2f, 1f, 1f);
        yield return new WaitForSeconds(6f);
        transform.localScale = new Vector3(transform.localScale.x / 2f, 1f, 1f);
    }

    public void LoseHealth(int i = 1)
    {
        if (health > 1)
        {
            health -= i;
            healthcount.text = health.ToString();
        }
        else
        {
            healthcount.text = "0";
            gameovertext.gameObject.SetActive(true);
            playbutton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Reset()
    {
        health = 3;
        healthcount.text = health.ToString();
        transform.position = new Vector3(0f, -3.5f, 0f);
        StopAllCoroutines();
        transform.localScale = new Vector3(2f, 1f, 1f);
    }
}
