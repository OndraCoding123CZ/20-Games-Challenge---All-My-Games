using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float stopPositionX;
    [SerializeField] public float stopPositionY;
    [SerializeField] public float enemyMoveSpeed;
    public bool hasBeenInstantiated = false;
    private bool hasReachedStopX = false;
    private bool hasReachedStopY = false;
    public bool bulletLaunchedByEnemy = false;

    [SerializeField] GameObject Bullet;
    GameObject EnemyNose;

    Vector2 bulletSpawnPosition;

    public List<GameObject> EnemyBullets = new List<GameObject>();

    GameManagerScript gameManagerScript;
    BulletScript bulletScript;
    GameObject PlayerSpaceShip;

    [SerializeField] float bulletStartingSpeed = 5f;
    [SerializeField] float fireInterval = 3f;

    void Start()
    {

        PlayerSpaceShip = GameObject.FindWithTag("Player");
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
        bulletScript = FindAnyObjectByType<BulletScript>();

        StartCoroutine(FireLoop());

    }

    void Update()
    {

        if (!hasReachedStopX)
        {

            transform.Translate(Vector3.right * enemyMoveSpeed * Time.deltaTime);

            if (transform.position.x >= stopPositionX)
            {

                transform.position = new Vector3(stopPositionX, transform.position.y, transform.position.z);
                hasReachedStopX = true;

            }
        }

        //if (hasReachedStopX && !hasReachedStopY)
        //{
        //transform.Translate(Vector3.down * enemyMoveSpeed * Time.deltaTime);

        //if (transform.position.y <= stopPositionY)
        //{

        //transform.position = new Vector3(transform.position.x, stopPositionY, transform.position.z);
        //hasReachedStopY = true;

        //}
        //}
    }

    IEnumerator FireLoop()
    {

        while (true)
        {

            StartCoroutine(TrackAndFireAtThePlayer());

            yield return new WaitForSeconds(3f);

        }
    }

    public IEnumerator TrackAndFireAtThePlayer()
    {

        if (gameManagerScript != null && gameManagerScript.instantiatedEnemies >= 5 && PlayerSpaceShip != null)
        {

            EnemyNose = FindAnyObjectByType<GameObject>();

            Vector2 playerPosition = PlayerSpaceShip.transform.position;
            bulletSpawnPosition = EnemyNose.transform.position;

            var bullet = Instantiate(Bullet, bulletSpawnPosition, Quaternion.identity);
            bullet.GetComponent<BulletScript>();
            bulletLaunchedByEnemy = true;

            yield return new WaitForSeconds(0.5f);

            bullet.GetComponent<BulletScript>().Init(playerPosition, bulletStartingSpeed);

            EnemyBullets.Add(bullet);

            yield return new WaitForSeconds(3f);

        }
        else
        {

            yield return new WaitForSeconds(0.2f);

        }
    }
}
