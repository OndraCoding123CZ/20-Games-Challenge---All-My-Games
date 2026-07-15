using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnButtonClickScript : MonoBehaviour
{

    [SerializeField] GameObject PongBall;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject ScreenCover;
    [SerializeField] GameObject displayText1;
    [SerializeField] GameObject displayText2;
    [SerializeField] TextMeshProUGUI displayText1TMP;
    [SerializeField] TextMeshProUGUI displayText2TMP;

    [SerializeField] PongBallMovement pongBallMovement;
    [SerializeField] EnemyAIScript enemyAIScript;
    [SerializeField] PlayerMovement playerMovement;

    List<GameObject> gameObjectsToSetActive = new List<GameObject>();
    List<GameObject> gameObjectsToSetFalse = new List<GameObject>();

    void Start()
    {

        gameObjectsToSetActive.Add(PongBall);
        gameObjectsToSetActive.Add(displayText1);
        gameObjectsToSetActive.Add(displayText2);

        gameObjectsToSetFalse.Add(gameOverText);
        gameObjectsToSetFalse.Add(ScreenCover);
        gameObjectsToSetFalse.Add(gameObject);

    }
    
    public void OnButtonClick()
    {

        if (PongBall != null && gameOverText != null)
        {

            foreach (GameObject obj in gameObjectsToSetActive)
            {

                obj.SetActive(true);

            }

            foreach (GameObject obj in gameObjectsToSetFalse)
            {

                obj.SetActive(false);

            }

            playerMovement.catchedPongBalls = 0f;
            enemyAIScript.catchedPongBalls = 0f;

            displayText1TMP.text = "" + playerMovement.catchedPongBalls;
            displayText2TMP.text = "" + enemyAIScript.catchedPongBalls;

            PongBall.transform.position = new Vector2(0, 0);

            bool isRight = UnityEngine.Random.value >= 0.5f;

            float xVelocity = -1f;

            if (isRight)
            {

                xVelocity = 1f;

            }

            float yVelocity = UnityEngine.Random.Range(-1, 1);

            pongBallMovement._rb.linearVelocity = new Vector2(xVelocity * pongBallMovement.startingSpeed, yVelocity * pongBallMovement.startingSpeed);

        }
    }
}
