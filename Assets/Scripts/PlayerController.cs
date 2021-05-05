using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float xInput;
    public float speed;
    public UnityEngine.UI.Text scoreboard;
    int score;
    bool powered;
    float originalXScale;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreboard.text = score.ToString();
        powered = false;
        originalXScale = transform.localScale.x;
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
        if (!powered)
        {
            powered = true;
            transform.localScale = new Vector3(originalXScale * 2f, 1f, 1f);
            yield return new WaitForSecondsRealtime(6f);
            transform.localScale = new Vector3(originalXScale, 1f, 1f);
            powered = false;
        }
    }
}
