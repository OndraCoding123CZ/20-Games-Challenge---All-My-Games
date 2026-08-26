using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    float asteroidStartSpeed = 1.5f;

    GameManagerScript gameManagerScript;

    void Start()
    {
        
    }

    void Update()
    {

        gameManagerScript = FindAnyObjectByType<GameManagerScript>();

        MoveAsteroid();
        RestrictAsteroidsFromMovingTooFar();

    }

    void MoveAsteroid()
    {

        transform.Translate(Vector2.up * asteroidStartSpeed * Time.deltaTime);
        Physics2D.SyncTransforms();

    }

    void RestrictAsteroidsFromMovingTooFar()
    {

        Vector2 asteroidPosition = transform.position;

        if (transform.position.x >= 12)
        {

            asteroidPosition.x = -11;

        }
        else if (transform.position.x <= -12)
        {

            asteroidPosition.x = 11;

        }

        if (transform.position.y >= 5)
        {

            asteroidPosition.y = -4;

        }
        else if (transform.position.y <= -5)
        {

            asteroidPosition.y = 4;

        }

        transform.position = asteroidPosition;

    }
}
