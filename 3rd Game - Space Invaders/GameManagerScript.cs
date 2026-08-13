using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] PlayerSpaceShipMovement playerSpaceShipMovement;

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject SpaceShipNose;

    public float enemyMoveSpeed = 5f;
    public float instantiatedEnemies = 0;
    public float baseStopPosition = 9f;
    public float stopSpacing = 4.5f;
    public float bulletStartingSpeed = 10f;
    public float enemiesDestroyed = 0f;
    public bool bulletLaunchedByPlayer = false;

    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> PlayerBullets = new List<GameObject>();

    [SerializeField] Rigidbody2D _rb;

    public List<GameObject> enemiesInstantiated = new List<GameObject>();

    TextMeshProUGUI scoreText;

    EnemyScript enemyScript;

    private Coroutine running;

    void Start()
    {

        StartCoroutine(InstantiateAndMoveEnemies());

        scoreText = FindAnyObjectByType<TextMeshProUGUI>();
        enemyScript = FindAnyObjectByType<EnemyScript>();

    }

    void Update()
    {

        UpdateScore();
        StartCoroutine(FireBullet());

    }

    IEnumerator InstantiateAndMoveEnemies()
    {

        while (true)
        {

            Vector2 spawnPosition = new Vector2(-20, 3.5f);
            GameObject newEnemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);
            Enemies.Add(newEnemy);

            EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();

            if (enemyScript != null)
            {

                float calculatedStopPosition = baseStopPosition - (instantiatedEnemies * stopSpacing);

                enemyScript.stopPositionX = calculatedStopPosition;
                enemyScript.enemyMoveSpeed = enemyMoveSpeed;

            }

            enemiesInstantiated.Add(newEnemy);
            instantiatedEnemies++;

            if (instantiatedEnemies >= 5f)
            {

                break;

            }

            yield return new WaitForSeconds(2);

        }
    }

    IEnumerator FireBullet()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 bulletSpawnPosition = SpaceShipNose.transform.position;
            GameObject bullet = Instantiate(Bullet, bulletSpawnPosition, Quaternion.identity);

            Vector2 yVelocity = new Vector2(0, 1.5f);

            bullet.GetComponent<Rigidbody2D>().linearVelocity = yVelocity * bulletStartingSpeed;

            PlayerBullets.Add(bullet);

            yield return new WaitForSeconds(2.5f);

            Destroy(bullet);

        }
    }

    public void UpdateScore()
    {

        scoreText.text = "Score: " + enemiesDestroyed;

    }
}
