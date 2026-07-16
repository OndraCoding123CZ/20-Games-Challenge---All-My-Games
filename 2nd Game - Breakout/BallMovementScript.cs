using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMovementScript : MonoBehaviour
{

    public Rigidbody2D _rb;
    public float startingSpeed;

    public float score;
    public float livesCounter = 3;
    public float previousScore;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesCounterText;
    [SerializeField] TextMeshProUGUI previousScoreText;

    [SerializeField] GameObject GreenCover;
    [SerializeField] GameObject scoreTextGO;
    [SerializeField] GameObject livesCounterTextGO;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject GameOverText;

    [SerializeField] GameObject youHaveDoneItGO;
    [SerializeField] GameObject youAreAlmostThereGO;
    [SerializeField] GameObject previousScoreGO;

    AudioSource playOnPlayerCollision;

    [SerializeField] GameObject Player;

    List<GameObject> gameObjectsSetToFalse = new List<GameObject>();
    List<GameObject> gameObjectsSetToTrue = new List<GameObject>();

    void Start()
    {

        gameObjectsSetToFalse.Add(scoreTextGO);
        gameObjectsSetToFalse.Add(livesCounterTextGO);
        gameObjectsSetToFalse.Add(gameObject);
        gameObjectsSetToFalse.Add(previousScoreGO);

        gameObjectsSetToTrue.Add(Panel);
        gameObjectsSetToTrue.Add(GameOverText);
        gameObjectsSetToTrue.Add(GreenCover);

        playOnPlayerCollision = GetComponent<AudioSource>();

    }

    void SaveAndDisplayPreviousScore()
    {

        previousScore = score;
        previousScoreText.text = "Previous Score: " + previousScore;

    }

    void Update()
    {

        SetTextActiveThenFalse();

        if (score == 240)
        {

            SaveAndDisplayPreviousScore();

            Panel.SetActive(true);
            youHaveDoneItGO.SetActive(true);
            GreenCover.SetActive(true);

            gameObject.SetActive(false);
            livesCounterTextGO.SetActive(false);
            scoreTextGO.SetActive(false);
            Player.SetActive(false);
            previousScoreGO.SetActive(false);
            
            score = 0;

            livesCounter = 3;

            scoreText.text = "Score: " + score;

            livesCounterText.text = "Lives: " + livesCounter;

        }

        if (livesCounter <= 0)
        {

            SaveAndDisplayPreviousScore();

            score = 0;
            scoreText.text = "Score: " + score;

            foreach (GameObject obj in gameObjectsSetToFalse)
            {

                obj.SetActive(false);

            }

            foreach (GameObject obj in gameObjectsSetToTrue)
            {

                obj.SetActive(true);

            }

            livesCounter = 3;
            livesCounterText.text = "Lives: " + livesCounter;

        }
    }

    void SetTextActiveThenFalse()
    {

        if (score == 150)
        {

            youAreAlmostThereGO.SetActive(true);

        }

        if (score != 150)
        {

            youAreAlmostThereGO.SetActive(false);

        }
    }

    void PlayOnCollisionMusic()
    {

        if (!playOnPlayerCollision.isPlaying)
        {

            playOnPlayerCollision.Play();

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            float xVelocity = Random.Range(-2.5f, 2.5f);
            float yVelocity = 3.5f;

            _rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);

            PlayOnCollisionMusic();

        }

        if (collision.gameObject.CompareTag("Blocks"))
        {

            collision.gameObject.SetActive(false);

            score += 10;

            scoreText.text = "Score: " + score;

        }

        if (collision.gameObject.CompareTag("GroundBarrier"))
        {

            livesCounter--;

            livesCounterText.text = "Lives: " + livesCounter; 
            
        }
    }
}
