using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField] GameObject PongBall;
    public TextMeshProUGUI displayText;

    public float catchedPongBalls = 0f;

    Vector2 position;

    void Update()
    {

        StartCoroutine(EnemyAI());

        position = transform.position;
        position.y = Mathf.Clamp(position.y, -3.3f, 3.3f);
        transform.position = position;

    }

    IEnumerator EnemyAI()
    {

        Vector2 pos = transform.position;
        pos.y = PongBall.transform.position.y;

        yield return new WaitForSeconds(0.45f);

        transform.position = pos;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("PongBall"))
        {

            catchedPongBalls++;

            displayText.text = "" + catchedPongBalls;

        }
    }
}
