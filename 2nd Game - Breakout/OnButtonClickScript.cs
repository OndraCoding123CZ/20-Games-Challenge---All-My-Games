using System.Collections.Generic;
using UnityEngine;

public class OnButtonClickScript : MonoBehaviour
{

    [SerializeField] GameObject GreenCover;
    [SerializeField] GameObject scoreTextGO;
    [SerializeField] GameObject livesCounterTextGO;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject Ball;

    [SerializeField] GameObject Player;

    [SerializeField] GameObject youHaveDoneItGO;
    [SerializeField] GameObject previousScoreGO;

    [SerializeField] GameObject Block1;
    [SerializeField] GameObject Block2;
    [SerializeField] GameObject Block3;
    [SerializeField] GameObject Block4;
    [SerializeField] GameObject Block5;
    [SerializeField] GameObject Block6;
    [SerializeField] GameObject Block7;
    [SerializeField] GameObject Block8;
    [SerializeField] GameObject Block9;
    [SerializeField] GameObject Block10;
    [SerializeField] GameObject Block11;
    [SerializeField] GameObject Block12;
    [SerializeField] GameObject Block13;
    [SerializeField] GameObject Block14;
    [SerializeField] GameObject Block15;
    [SerializeField] GameObject Block16;
    [SerializeField] GameObject Block17;
    [SerializeField] GameObject Block18;
    [SerializeField] GameObject Block19;
    [SerializeField] GameObject Block20;
    [SerializeField] GameObject Block21;
    [SerializeField] GameObject Block22;
    [SerializeField] GameObject Block23;
    [SerializeField] GameObject Block24;

    List<GameObject> gameObjectsSetToFalse = new List<GameObject>();
    List<GameObject> gameObjectsSetToTrue = new List<GameObject>();

    List<GameObject> Blocks = new List<GameObject>();

    void Start()
    {

        gameObjectsSetToFalse.Add(GreenCover);
        gameObjectsSetToFalse.Add(gameObject);
        gameObjectsSetToFalse.Add(GameOverText);
        gameObjectsSetToFalse.Add(youHaveDoneItGO);

        gameObjectsSetToTrue.Add(scoreTextGO);
        gameObjectsSetToTrue.Add(livesCounterTextGO);
        gameObjectsSetToTrue.Add(Ball);
        gameObjectsSetToTrue.Add(Player);
        gameObjectsSetToTrue.Add(previousScoreGO);

        Blocks.Add(Block1);
        Blocks.Add(Block2);
        Blocks.Add(Block3);
        Blocks.Add(Block4);
        Blocks.Add(Block5);
        Blocks.Add(Block6);
        Blocks.Add(Block7);
        Blocks.Add(Block6);
        Blocks.Add(Block7);
        Blocks.Add(Block8);
        Blocks.Add(Block9);
        Blocks.Add(Block10);
        Blocks.Add(Block11);
        Blocks.Add(Block12);
        Blocks.Add(Block13);
        Blocks.Add(Block14);
        Blocks.Add(Block15);
        Blocks.Add(Block16);
        Blocks.Add(Block17);
        Blocks.Add(Block18);
        Blocks.Add(Block19);
        Blocks.Add(Block20);
        Blocks.Add(Block21);
        Blocks.Add(Block22);
        Blocks.Add(Block23);
        Blocks.Add(Block24);

    }

    public void OnButtonClick()
    {

        foreach (GameObject obj in gameObjectsSetToFalse)
        {

            obj.SetActive(false);

        }

        foreach (GameObject obj in gameObjectsSetToTrue)
        {

            obj.SetActive(true);

            Ball.transform.position = new Vector2(0, -3);
            Player.transform.position = new Vector2(0, -4.4f);

        }

        foreach (GameObject obj in Blocks)
        {

            obj.SetActive(true);

        }
    }
}
