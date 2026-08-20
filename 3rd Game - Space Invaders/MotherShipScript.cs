using UnityEngine;

public class MotherShipScript : MonoBehaviour
{

    float moveSpeed = 3f;
    public float stopPositionX = 15;

    PanelScript panelScript;

    void Start()
    {

        panelScript = FindAnyObjectByType<PanelScript>();

    }


    void Update()
    {

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.x >= stopPositionX)
        {

            Destroy(gameObject);

        }
    }
}
