using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them
    public Rigidbody2D RB;
    public TextMeshPro ScoreText;
    public float Speed = 5;
    public int Score = 0;
    public int Health = 3;
    private SpriteRenderer spriteRenderer;

    //Start automatically gets triggered once when the objects turns on/the game starts
    void Start()
    {
        //During setup we call UpdateScore to make sure our score text looks correct
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateScore();
    }

    //Update is a lot like Start, but it automatically gets triggered once per frame
    void Update()
    {
        //The code below controls the character's movement
        Vector2 vel = new Vector2(0, 0);

        //Movement controls
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -Speed;
        }

        //Finally, I take that variable and I feed it to the component in charge of movement
        RB.linearVelocity = vel;
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        if (other.gameObject.CompareTag("Hazard"))
        {
            if(Health == 0)
            {
            //Run your 'you lose' function!
            Die();
            }
        }

        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        //If it does, run the code block below
        // if (coin != null)
        // {
        //     //Tell the coin that you bumped into them so they can self destruct or whatever
        //     coin.GetBumped();
        //     //Make your score variable go up by one. . .
        //     Score++;
        //     //And then update the game's score text
        //     UpdateScore();

        //     if(Score >= 2)
        //     {
        //     SceneManager.LoadScene("Game Over");
        //     }
        // }
    }

    //This function updates the game's score text to show how many points you have
public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
}