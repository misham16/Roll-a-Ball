using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
public float speed;
public Text countText;
public Text winText;
public Text scoreText;
public Text livesText;

private Rigidbody rb;
private int count;
private int score;
private int lives;

void Start ()
{
    rb = GetComponent<Rigidbody>();
    count = 0;
    score = 0;
    lives = 3;
    SetCountText ();
    SetScoreText ();
    SetLivesText ();
    winText.text = "";
}
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce (movement * speed);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText ();
            SetScoreText ();
            SetLivesText ();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            lives = lives - 1;
            SetCountText ();
            SetScoreText ();
            SetLivesText ();
        }
         if (count == 12)
        {
            transform.position = new Vector3(50, transform.position.y, 0);
        }
    }
    void SetCountText ()
    {
        countText.text = "Total: " + count.ToString ();
        if (count >= 25)
        {
            winText.text = "Your score is " + score.ToString ();
        }
    }
    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score == 24)
        {
            winText.text = "You Win!! ";
        }
    }
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            gameObject.SetActive(false);
            winText.text = "GAME OVER";
        }
    }
}