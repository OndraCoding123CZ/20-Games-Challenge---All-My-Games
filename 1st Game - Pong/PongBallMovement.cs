using TMPro;
using UnityEngine;

public class PongBallMovement : MonoBehaviour
{

    public Rigidbody2D _rb;
    public float startingSpeed;

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject ScreenCover;
    [SerializeField] GameObject displayText1;
    [SerializeField] GameObject displayText2;

    void Start()
    {

        bool isRight = UnityEngine.Random.value >= 0.5f;

        float xVelocity = -1f;

        if (isRight)
        {

            xVelocity = 1f;

        }

        float yVelocity = UnityEngine.Random.Range(-1, 1);

        _rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("SideWall"))
        {

            gameOverText.SetActive(true);
            Panel.SetActive(true);
            ScreenCover.SetActive(true);
            displayText1.SetActive(false);
            displayText2.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
