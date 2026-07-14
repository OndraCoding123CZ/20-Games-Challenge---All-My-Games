using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    float _moveSpeed = 3.5f;
    Vector2 position;

    public TextMeshProUGUI displayText;

    public float catchedPongBalls = 0f;

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {

            gameObject.transform.Translate(new Vector2(0f, _moveSpeed) * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {

            gameObject.transform.Translate(new Vector2(0f, -_moveSpeed) * Time.deltaTime);

        }

        position = transform.position;
        position.y = Mathf.Clamp(position.y, -3.3f, 3.3f);
        transform.position = position;

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
