using UnityEngine;

public class PlayerSpaceShipMovement : MonoBehaviour
{

    float _moveSpeed = 5f;
    public bool isMoving = false;
    public float bulletMoveSpeed = 4f;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.Translate(new Vector2(-_moveSpeed, 0f) * Time.deltaTime);

            isMoving = true;

        }

        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.Translate(new Vector2(_moveSpeed, 0f) * Time.deltaTime);

            isMoving = true;

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {

            isMoving = false;

        }
    }
}
