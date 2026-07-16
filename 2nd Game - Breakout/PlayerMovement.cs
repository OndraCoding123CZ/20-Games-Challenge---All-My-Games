using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float _moveSpeed = 9f; // 5f

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.Translate(new Vector2(-_moveSpeed, 0f) * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.Translate(new Vector2(_moveSpeed, 0f) * Time.deltaTime);

        }

        Vector2 position = gameObject.transform.position;
        position.x = Mathf.Clamp(position.x, -8.15f, 8.15f);
        gameObject.transform.position = position;

    }
}
