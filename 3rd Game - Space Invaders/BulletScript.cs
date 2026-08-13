using System.Collections;
using TMPro;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    GameManagerScript gameManagerScript;
    EnemyScript enemyScript;
    GameObject PlayerSpaceShip;

    public float enemiesDestroyed = 0f;
    public bool bulletNotLaunchedByEnemy = false;

    TextMeshProUGUI scoreText;

    Vector2 target;
    public float speed;

    void Start()
    {

        scoreText = FindAnyObjectByType<TextMeshProUGUI>();
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
        enemyScript = FindAnyObjectByType<EnemyScript>();
        PlayerSpaceShip = GameObject.FindGameObjectWithTag("Player");

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

        if (collision.gameObject.CompareTag("Enemy"))
        {

            //Destroy(collision.gameObject);
            //Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Player"))
        {

            //Destroy(collision.gameObject);
            //Destroy(gameObject);

        }
    }
}
