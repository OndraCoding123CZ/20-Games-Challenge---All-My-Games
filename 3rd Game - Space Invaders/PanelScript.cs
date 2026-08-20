using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.ShadowCascadeGUI;

public class PanelScript : MonoBehaviour
{

    [SerializeField] GameObject ScreenCover;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject PlayerSpaceShip;
    [SerializeField] GameObject LivesText;

    public bool enemiesCantBeSetActive = true;
    public bool motherShipCanBeSetActive = false;
    public bool buttonHasBeenClicked = true;

    List<GameObject> gameObjectsToSetActive = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactive = new List<GameObject>();

    [SerializeField] EnemyBulletScript enemyBulletScript;
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] EnemyScript enemyScript;

    AudioSource[] audioSources;

    void Start()
    {

        audioSources = FindAnyObjectByType<AudioSource>().GetComponents<AudioSource>();

        gameObjectsToSetActive.Add(ScoreText);
        gameObjectsToSetActive.Add(LivesText);
        gameObjectsToSetActive.Add(PlayerSpaceShip);

        gameObjectsToSetInactive.Add(ScreenCover);
        gameObjectsToSetInactive.Add(Panel);
        
    }

    public void OnButtonClick()
    {

        enemiesCantBeSetActive = false;
        motherShipCanBeSetActive = true;
        buttonHasBeenClicked = true;

        audioSources[0].Play();

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
    }
}
