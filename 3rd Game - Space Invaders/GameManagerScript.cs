using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] PlayerSpaceShipMovement playerSpaceShipMovement;

    [SerializeField] GameObject PlayerBullet;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject ScreenCover;
    [SerializeField] GameObject PlayerSpaceShipNose;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject MotherShip;
    [SerializeField] GameObject LivesText;
    GameObject PlayerSpaceShip;

    public float enemyMoveSpeed = 5f;
    public float instantiatedEnemies = 0;
    public float baseStopPosition = 9f;
    public float stopSpacing = 4.5f;
    public float bulletStartingSpeed = 10f;
    public float enemiesDestroyed = 0f;
    public bool bulletLaunchedByPlayer = false;
    public bool playerDestroyed = false;
    public float playerLives = 3f;
    bool playerDestroyedCanBeSetFalse = false;
    public bool instantiatedEnemiesAreBackAt0 = false;
    public bool playerLivesAreBelow0 = false;
    public bool playerIsFrozen = false;

    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> PlayerBullets = new List<GameObject>();
    public List<GameObject> MotherShips = new List<GameObject>();

    List<GameObject> gameObjectsToSetActive = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactive = new List<GameObject>();

    [SerializeField] Rigidbody2D _rb;

    public List<GameObject> enemiesInstantiated = new List<GameObject>();

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    EnemyScript enemyScript;
    [SerializeField] EnemyBulletScript enemyBulletScript;
    [SerializeField] PlayerBulletScript playerBulletScript;
    [SerializeField] PanelScript panelScript;

    AudioSource[] audioSources;

    void Start()
    {

        StartCoroutine(CheckIfCoroutineCanBeStarted());
        
        enemyScript = FindAnyObjectByType<EnemyScript>();
        audioSources = FindAnyObjectByType<AudioSource>().GetComponents<AudioSource>();
        
        gameObjectsToSetActive.Add(Panel);
        gameObjectsToSetActive.Add(ScreenCover);
        gameObjectsToSetActive.Add(PlayerSpaceShip);

        gameObjectsToSetInactive.Add(ScoreText);
        gameObjectsToSetInactive.Add(LivesText);

        StartCoroutine(ShowPlayAgainScreen());
        StartCoroutine(CheckIfSetMotherShipActiveCanBeStarted());
        StartCoroutine(PurposelyLagTheGame());

    }

    void Update()
    {

        PlayerSpaceShip = FindAnyObjectByType<GameObject>();

        UpdateScoreAndLives();
        StartCoroutine(FireBullet());

        foreach (GameObject obj in MotherShips)
        {

            if (playerDestroyed && panelScript.motherShipCanBeSetActive == false && obj != null)
            {

                obj.SetActive(false);

            }
        }
    }

    IEnumerator SetMotherShipActive()
    {

        Vector2 spawnPosition = new Vector2(-15, 0);

        var motherShip = Instantiate(MotherShip, spawnPosition, Quaternion.identity);
        MotherShips.Add(motherShip);

        yield return new WaitForSeconds(5f);

    }

    IEnumerator PurposelyLagTheGame()
    {

        while (true)
        {

            Time.timeScale = 0f;

            yield return new WaitForSecondsRealtime(0.25f);

            Time.timeScale = 1f;

            yield return new WaitForSeconds(1f);

        }
    }

    public IEnumerator CheckIfSetMotherShipActiveCanBeStarted()
    {

        while (true)
        {

            if (panelScript.motherShipCanBeSetActive)
            {

                StartCoroutine(SetMotherShipActive());

            }

            if (playerDestroyed && panelScript.motherShipCanBeSetActive == false)
            {

                StopCoroutine(CheckIfSetMotherShipActiveCanBeStarted());

            }

            yield return new WaitForSeconds(5f);

        }
    }

    IEnumerator ShowPlayAgainScreen()
    {

        while (true)
        {

            if (playerLives <= 0)
            {

                enemiesDestroyed = 0f;
                instantiatedEnemies = 0f;
                panelScript.motherShipCanBeSetActive = false;
                panelScript.enemiesCantBeSetActive = true;
                UpdateScoreAndLives();

                audioSources[1].Play();

                foreach (GameObject obj in gameObjectsToSetActive)
                {

                    if (obj != null)
                    {

                        obj.SetActive(true);

                    }
                }

                foreach (GameObject obj in gameObjectsToSetInactive)
                {

                    if (obj != null)
                    {

                        obj.SetActive(false);

                    }
                }

                foreach (GameObject obj in Enemies)
                {

                    if (obj != null)
                    {

                        obj.SetActive(false);

                    }
                }

                foreach (GameObject obj in MotherShips)
                {

                    if (obj != null)
                    {

                        obj.SetActive(false);

                    }
                }

                yield return new WaitForSeconds(0.1f);

                playerLives = 3f;

            }

            yield return new WaitForSeconds(0.5f);

        }
    }

    public IEnumerator CheckIfCoroutineCanBeStarted()
    {

        while (true)
        {

            if (panelScript.enemiesCantBeSetActive == false)
            {

                StartCoroutine(InstantiateAndMoveEnemies());

                if (instantiatedEnemies >= 5f)
                {

                    StopCoroutine(InstantiateAndMoveEnemies());

                }
            }

            yield return new WaitForSeconds(2f);

        }
    }

    public IEnumerator InstantiateAndMoveEnemies()
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

        yield return new WaitForSeconds(2);

    }

    IEnumerator FireBullet()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (PlayerSpaceShipNose != null)
            {

                Vector2 bulletSpawnPosition = PlayerSpaceShipNose.transform.position;
                GameObject playerBullet = Instantiate(PlayerBullet, bulletSpawnPosition, Quaternion.identity);

                Vector2 yVelocity = new Vector2(0, 1.5f);

                playerBullet.GetComponent<Rigidbody2D>().linearVelocity = yVelocity * bulletStartingSpeed;

                PlayerBullets.Add(playerBullet);

                yield return new WaitForSeconds(2.5f);

                Destroy(playerBullet);

            }
        }
    }

    public void UpdateScoreAndLives()
    {

        scoreText.text = "Score: " + enemiesDestroyed;
        livesText.text = "Lives: " + playerLives;

    }
}
