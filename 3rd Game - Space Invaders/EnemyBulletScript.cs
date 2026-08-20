using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    GameManagerScript gameManagerScript;
    EnemyScript enemyScript;

    public float enemiesDestroyed = 0f;
    public bool bulletNotLaunchedByEnemy = false;
    public bool playerDestroyed = false;

    TextMeshProUGUI scoreText;

    Vector2 target;
    public float speed;

    List<GameObject> gameObjectsToSetActive = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactive = new List<GameObject>();

    void Start()
    {

        scoreText = FindAnyObjectByType<TextMeshProUGUI>();
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
        enemyScript = FindAnyObjectByType<EnemyScript>();

    }

    public void Init(Vector2 target, float speed)
    {

        this.target = target;
        this.speed = speed;

    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            gameManagerScript.playerLives--;

            if (gameManagerScript.playerLives <= 0)
            {

                collision.gameObject.SetActive(false);
                gameManagerScript.playerDestroyed = true;
                gameManagerScript.playerLivesAreBelow0 = true;

            }

            Destroy(gameObject);

        }
    }
}
