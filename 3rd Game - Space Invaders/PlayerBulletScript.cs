using TMPro;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{

    GameManagerScript gameManagerScript;


    void Start()
    {

        gameManagerScript = FindAnyObjectByType<GameManagerScript>();

    }


    void Update()
    {
        


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            gameManagerScript.enemiesDestroyed += 10;
            gameManagerScript.UpdateScoreAndLives();

            collision.gameObject.SetActive(false);
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("MotherShip"))
        {

            gameManagerScript.enemiesDestroyed += 30;
            gameManagerScript.UpdateScoreAndLives();

            collision.gameObject.SetActive(false);
            Destroy(gameObject);

        }    
    }
}
